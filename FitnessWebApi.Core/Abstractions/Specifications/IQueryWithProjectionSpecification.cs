using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public interface IQueryWithProjectionSpecification<TDocument,TProjection> : IQuerySpecification<TDocument> 
        where TDocument : class, IDocument 
        where TProjection: class
    {
        ProjectionDefinition<TDocument, TProjection> ProjectionDefinition { get; }

        IQuerySpecification<TDocument> GetBaseObject();
    }
}
