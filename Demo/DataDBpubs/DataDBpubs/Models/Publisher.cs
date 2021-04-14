using System;
using System.Collections.Generic;

#nullable disable

namespace DataDBpubs.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Employees = new HashSet<Employee>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
