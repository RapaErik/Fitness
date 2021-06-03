using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Abstractions.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FitnessWebApi.Core.Abstractions.Repository
{
    public interface IRepository<TDocument> where TDocument: class, IDocument
       
    {
        Task<IList<TDocument>> FindManyAsync(IQuerySpecification<TDocument> specification);


        Task<IList<TProjection>> FindManyAsync<TProjection>(IQueryWithProjectionSpecification<TDocument, TProjection> specification) where TProjection : class;

        //TODO: for single object

        Task<bool> UpdateAsync<TProjection>(IUpdateSpecification<TDocument, TProjection> specification) where TProjection : class;

    }
}
