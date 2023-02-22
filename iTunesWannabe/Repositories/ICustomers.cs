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
        public void PrintAllCustomerInfo(List<Customer> customers, bool displayInvoice = false);
        public void PrintCustomerInfo(Customer customer, bool displayInvoice = false);
        public void AddNewElement(Customer customer);
        public void UpdateElement(Customer customer, int idIndex);
        public string GetHabitantsPerCountry();
        public List<Customer> GetHighestSpenders();
        public string GetMostPopularGenre(int customerId);
    }
}
