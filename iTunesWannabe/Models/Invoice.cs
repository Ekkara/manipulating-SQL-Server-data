using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesWannabe.Models
{
    public class Invoice
    {
        public Invoice(int customerId, decimal sum)
        {
            CustomerId = customerId;
            Total = sum;
        }
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}
