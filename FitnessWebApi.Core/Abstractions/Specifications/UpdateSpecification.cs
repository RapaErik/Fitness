using FitnessWebApi.Core.Abstractions.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Abstractions.Specifications
{
    public abstract class UpdateSpecification<TDocument, TProjection> : IUpdateSpecification<TDocument, TProjection> where TDocument : class, IDocument
       where TProjection : class
    {
        public FilterDefinition<TDocument> FilterDefinition { get; private set; }
        public UpdateDefinition<TDocument> UpdateDefinition { get; private set; }
        public FindOneAndUpdateOptions<TDocument, TProjection> Options { get; private set; }

        public UpdateSpecification()
        {
            FilterDefinition = SetFilterDefinition();
            UpdateDefinition= SetUpdateDefinition();
            Options = SetOptions();
        }
        public abstract FilterDefinition<TDocument> SetFilterDefinition();
        public abstract UpdateDefinition<TDocument> SetUpdateDefinition();

        public abstract FindOneAndUpdateOptions<TDocument, TProjection> SetOptions();
    }
}
