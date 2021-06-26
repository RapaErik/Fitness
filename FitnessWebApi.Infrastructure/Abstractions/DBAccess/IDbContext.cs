using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;

namespace FitnessWebApi.Infrastructure.Abstractions.DBAccess
{
    public interface IDbContext
    {
        void CreateClient();
        IMongoDatabase GetDatabase();
        IMongoCollection<TDocument> GetCollection<TDocument>() where TDocument : class, IDocument;
    }
}
