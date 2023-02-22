using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository customerRep = new();
//List<Customer> customerList = customerRep.GetHighestSpenders();
//customerRep.PrintAllCustomerInfo(customerList, true);
for (int i = 0; i < 50; i++)
{
    Console.WriteLine(customerRep.GetMostPopularGenre(i));
}
