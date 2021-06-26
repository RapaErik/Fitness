using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Attributes;
using System;

namespace FitnessWebApi.Core.Models
{
   [CollectionName("Customers")]
   public class Customer: IDocument
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string  Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
