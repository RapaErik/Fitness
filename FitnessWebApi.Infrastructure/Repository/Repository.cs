using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Abstractions.Repository;
using FitnessWebApi.Core.Abstractions.Specifications;
using FitnessWebApi.Infrastructure.Abstractions.DBAccess;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebApi.Infrastructure.Repository
{
    public class Repository<TDocument> : IRepository<TDocument> where TDocument : class, IDocument
    {
        private readonly IDbContext _context;
        private readonly IMongoCollection<TDocument> _collection;
        public Repository(IDbContext context)
        {
            _context = context;
            _collection = context.GetCollection<TDocument>();
        }
        public async Task<IList<TDocument>> FindManyAsync(IQuerySpecification<TDocument> specification)
        {
            return  await SpecificationBuilder<TDocument>.BuildQuery(_collection, specification).ToListAsync();
        }

        public async Task<IList<TProjection>> FindManyAsync<TProjection>(IQueryWithProjectionSpecification<TDocument, TProjection> specification) where TProjection : class
        {
            return await SpecificationBuilder<TDocument>.BuildQuery(_collection, specification).ToListAsync();
        }

        public Task<bool> UpdateAsync<TProjection>(IUpdateSpecification<TDocument, TProjection> specification) where TProjection : class
        {
           
        }
    }
}
