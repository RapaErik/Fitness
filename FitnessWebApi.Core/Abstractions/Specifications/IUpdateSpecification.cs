using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public interface IUpdateSpecification<TDocument, TProjection> where TDocument : class, IDocument
        where TProjection : class
    {
        FilterDefinition<TDocument> FilterDefinition { get; }
        UpdateDefinition<TDocument> UpdateDefinition { get; }
        FindOneAndUpdateOptions<TDocument, TProjection> Options { get; }

        
    }
}
