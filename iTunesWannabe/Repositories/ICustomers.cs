using iTunesWannabe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesWannabe.Repositories
{
    public interface ICustomers : IRepository<Customer>
    {
        public void GetAllCustomerInfo(List<Customer> customers);
        public void PrintCustomerInfo(Customer customer);
        public void AddNewElement(Customer customer);
    }
}
