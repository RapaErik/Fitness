using FitnessWebApi.Core.Abstractions.Specifications;
using FitnessWebApi.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Specifications
{
    public class FindAllCustomersSpecification : QuerySpecification<Customer>
    {
        public override FilterDefinition<Customer> SetFilterDefinition()
        {
            return Builders<Customer>.Filter.Empty;
        }

        public override FindOptions SetFindOptionsn()
        {
            return null;
        }

        public override int? SetLimit()
        {
            return null;
        }

        public override int? SetSkip()
        {
            return null;
        }

        public override SortDefinition<Customer> SetSortDefinition()
        {
            return Builders<Customer>.Sort.Ascending(x => x.FirstName);
        }
    }
}
