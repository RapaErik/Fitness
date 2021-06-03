using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Models
{
    [CollectionName("Employees")]
    public class Employee :IDocument
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
