using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public abstract class QuerySpecification<TDocument> : IQuerySpecification<TDocument> where TDocument : class, IDocument
    {
        public FilterDefinition<TDocument> FilterDefinition { get; private set; }
        public SortDefinition<TDocument> SortDefinition { get; private set; }
        public int? Skip { get; private set; }
        public int? Limit { get; private set; }
        public FindOptions FindOptions { get; private set; }

        public QuerySpecification()
        {
            FilterDefinition = SetFilterDefinition();
            SortDefinition= SetSortDefinition();
            Skip= SetSkip();
            Limit= SetLimit();
            FindOptions = SetFindOptionsn();
        }

        public abstract FilterDefinition<TDocument> SetFilterDefinition();
        public abstract SortDefinition<TDocument> SetSortDefinition();
        public abstract int? SetSkip();
        public abstract int? SetLimit();
        public abstract FindOptions SetFindOptionsn();
    }
} 
