using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_101_7_0_EntityFramework.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FisrtName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public ICollection<CustomerAddress> Addresses { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
