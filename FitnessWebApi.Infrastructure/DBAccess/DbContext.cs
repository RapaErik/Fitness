using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Attributes;
using FitnessWebApi.Infrastructure.Abstractions.DBAccess;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Linq;

namespace FitnessWebApi.Infrastructure.DBAccess
{
    public class DbContext : IDbContext
    {
        private readonly MongoOptions _mongoOptions;
        private MongoClient _mongoClient;
        public DbContext(IOptions<MongoOptions> options)
        {
            _mongoOptions = options?.Value ?? throw new ArgumentNullException(nameof(options));
        }
        public void CreateClient()
        {
            _mongoClient = new MongoClient(_mongoOptions.ConnectionString);
        }
        
        public IMongoDatabase GetDatabase()
        {
            return _mongoClient.GetDatabase(_mongoOptions.DbName);
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
