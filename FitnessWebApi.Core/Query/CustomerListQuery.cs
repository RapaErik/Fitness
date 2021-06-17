using FitnessWebApi.Core.Abstractions.Repository;
using FitnessWebApi.Core.Models;
using FitnessWebApi.Core.Specifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitnessWebApi.Core.Query
{
    public class CustomerListQuery : IRequest<IList<Customer>>
    {
        
    }
    public class CustomerListQueryHandler : IRequestHandler<CustomerListQuery, IList<Customer>>
    {
        private readonly IRepository<Customer> _repository;

        public CustomerListQueryHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<IList<Customer>> Handle(CustomerListQuery request, CancellationToken cancellationToken)
        {
            FindAllCustomersSpecification query = new FindAllCustomersSpecification();
            return await _repository.FindManyAsync(query);
        }
    }
}
