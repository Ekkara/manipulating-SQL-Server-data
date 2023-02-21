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
        public void PrintAllCustomerInfo(List<Customer> customers);
        public void PrintCustomerInfo(Customer customer);
        public void AddNewElement(Customer customer);
        public void UpdateElement(Customer customer, int idIndex);
        public List<Customer> SortCustomersByNationality();
    }
}
