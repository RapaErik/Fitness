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
        private readonly IMongoCollection<TDocument> _collection;
        public Repository(IDbContext context)
        {
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

        public async Task<TDocument> FindOneAsync(IQuerySpecification<TDocument> specification)
        {
            return await SpecificationBuilder<TDocument>.BuildQuery(_collection, specification).FirstOrDefaultAsync();
        }

        public async Task<TProjection> FindOneAsync<TProjection>(IQueryWithProjectionSpecification<TDocument, TProjection> specification) where TProjection : class
        {
            return await SpecificationBuilder<TDocument>.BuildQuery(_collection, specification).FirstOrDefaultAsync();
        }

        public async  Task<bool> UpdateAsync<TProjection>(IUpdateSpecification<TDocument, TProjection> specification) where TProjection : class
        {
            var result= await SpecificationBuilder<TDocument>.BuildUpdateAsync(_collection, specification);
            return result == null ? false : true;
        }
        public async Task<bool> UpdateAsync(IUpdateSpecification<TDocument, TDocument> specification)
        {
            var result = await SpecificationBuilder<TDocument>.BuildUpdateAsync(_collection, specification);
            return result == null ? false : true;
        }

        //TODO: create

        //TODO: delete

        //TODO: count

        
    }
}
