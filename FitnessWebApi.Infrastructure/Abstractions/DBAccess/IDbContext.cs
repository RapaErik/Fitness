using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Infrastructure.Abstractions.DBAccess
{
    public interface IDbContext
    {
        void CreateClient();
        IMongoDatabase GetDatabase();

        IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : class, IDocument;
    }
}
