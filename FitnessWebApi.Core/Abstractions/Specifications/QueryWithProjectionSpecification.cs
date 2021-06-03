using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public abstract class QueryWithProjectionSpecification<TDocument, TProjection> : QuerySpecification<TDocument>, IQueryWithProjectionSpecification<TDocument, TProjection> 
        where TDocument : class, IDocument
        where TProjection : class
    {
        public ProjectionDefinition<TDocument, TProjection> ProjectionDefinition { get; private set; }

        public QueryWithProjectionSpecification() : base()
        {
            ProjectionDefinition = SetProjectionDefinition();
        }
        public abstract ProjectionDefinition<TDocument> SetProjectionDefinition();

        public IQuerySpecification<TDocument> GetBaseObject()
        {
            return this;
        }
    }
}
