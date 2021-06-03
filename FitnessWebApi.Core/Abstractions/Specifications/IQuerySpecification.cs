using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public interface IQuerySpecification<TDocument> where TDocument : class, IDocument
    {
        FilterDefinition<TDocument> FilterDefinition { get; }
        SortDefinition<TDocument> SortDefinition { get; }
        int? Skip { get; }
        int? Limit { get; }
        FindOptions FindOptions { get; }
        
    }
}
