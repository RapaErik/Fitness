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
                findFluent = collection.Find(querySpecification.FilterDefinition,querySpecification.FindOptions);
            }

            if(querySpecification.SortDefinition != null)
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
            if (querySpecification.ProjectionDefinition!=null)
            {
                findFluentResult = findFluent.Project(querySpecification.ProjectionDefinition);
            }
            
            return findFluentResult;
        }
        
        //TODO: Builder for Updates
    
    }
}
