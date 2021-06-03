using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessWebApi.Core.Models
{
    public class CheckIn
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public long TicketId { get; set; }
        public long EmploydeeId { get; set; }
        public  Room Room { get; set; }
    }
}
