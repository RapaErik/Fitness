using FitnessWebApi.Core.Models;
using FitnessWebApi.Core.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IList<Customer>> GetAllCustomersAsync()
        {
            return await _mediator.Send(new CustomerListQuery());
        }
    }
}
