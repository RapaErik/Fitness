using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Abstractions.Specifications;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebApi.Infrastructure
{
    public static class SpecificationBuilder<TDocument> where TDocument : class, IDocument
    {
        public static IFindFluent<TDocument, TDocument> BuildQuery(IMongoCollection<TDocument> collection, IQuerySpecification<TDocument> querySpecification)
        {
            IFindFluent<TDocument, TDocument> findFluent = default;

            if (querySpecification.FilterDefinition != null)
            {
                findFluent = collection.Find(querySpecification.FilterDefinition, querySpecification.FindOptions);
            }

            if (querySpecification.SortDefinition != null)
            {
                findFluent = findFluent.Sort(querySpecification.SortDefinition);
            }

            if (querySpecification.Skip != null)
            {
                findFluent = findFluent.Skip(querySpecification.Skip);
            }

            if (querySpecification.Limit != null)
            {
                findFluent = findFluent.Limit(querySpecification.Limit);
            }

            return findFluent;
        }
        public static IFindFluent<TDocument, TProjection> BuildQuery<TProjection>(IMongoCollection<TDocument> collection, IQueryWithProjectionSpecification<TDocument, TProjection> querySpecification)
            where TProjection : class
        {
            IFindFluent<TDocument, TDocument> findFluent = default;

            findFluent = BuildQuery(collection, querySpecification.GetBaseObject());

            IFindFluent<TDocument, TProjection> findFluentResult = default;
            if (querySpecification.ProjectionDefinition != null)
            {
                findFluentResult = findFluent.Project(querySpecification.ProjectionDefinition);
            }

            return findFluentResult;
        }

        public static async Task<TProjection> BuildUpdateAsync<TProjection>(IMongoCollection<TDocument> collection, IUpdateSpecification<TDocument, TProjection> updateSpecification)
    where TProjection : class
        {
            if (updateSpecification.FilterDefinition != null && updateSpecification.UpdateDefinition != null)
            {
                return await collection.FindOneAndUpdateAsync(updateSpecification.FilterDefinition, updateSpecification.UpdateDefinition, updateSpecification.Options);
            }
            return null;
        }
        public static async Task<TDocument> BuildUpdateAsync(IMongoCollection<TDocument> collection, IUpdateSpecification<TDocument, TDocument> updateSpecification)
        {
            if (updateSpecification.FilterDefinition != null && updateSpecification.UpdateDefinition != null)
            {
                return await collection.FindOneAndUpdateAsync(updateSpecification.FilterDefinition, updateSpecification.UpdateDefinition);

            }
            return null;
        }

        //TODO: create

        //TODO: delete

    }
}
