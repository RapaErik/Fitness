using FitnessWebApi.Core.Abstractions.Models;
using FitnessWebApi.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Models
{
    [CollectionName("Tickets")]
    public class Ticket : IDocument
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public TicketType Type { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
