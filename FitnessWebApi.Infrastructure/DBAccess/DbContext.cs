using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Attributes;
using FitnessWebApi.Infrastructure.Abstractions.DBAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessWebApi.Infrastructure.DBAccess
{
    public class DbContext : IDbContext
    {
        private readonly string _connectionString;
        private readonly string _dbName;
        private MongoClient _mongoClient;
        public DbContext(string connectionString, string dbName)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _dbName = dbName ?? throw new ArgumentNullException(nameof(dbName));
        }
        public void CreateClient()
        {
            _mongoClient = new MongoClient(_connectionString);
        }
        
        public IMongoDatabase GetDatabase()
        {
            return _mongoClient.GetDatabase(_dbName);
        }

        public IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : class, IDocument
        {
            return GetDatabase().GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }
        
        private static string GetCollectionName(Type documetType)
        {
            return (documetType.GetCustomAttributes(typeof(CollectionNameAttribute), false).FirstOrDefault() as CollectionNameAttribute).CollectionName;
        }
    }
}
