using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;

CustomerRepository getCustomerInfo = new CustomerRepository();


//getCustomerInfo.GetById(23);

foreach(Customer co in getCustomerInfo.GetPage(500, 0))
{
 //   Console.WriteLine(co.FirstName);
}
//getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Daan"));

//getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Marc"));

List<Customer> customers = new List<Customer>();
CustomerRepository customerRep = new();

//Act
customers = customerRep.GetAll();

//int index = 49;
//Console.WriteLine(expectedCustomers[index] == customers[index]);
//Console.WriteLine(expectedCustomers[index].ToString() + '\n' + customers[index].ToString());
//index = 4;
//Console.WriteLine(expectedCustomers[index] == customers[index]);
//Console.WriteLine(expectedCustomers[index].ToString() + '\n' + customers[index].ToString());


////Console.WriteLine(customers.Count + " : " + expectedCustomers.Count);
////for (int i = 0; i < customers.Count; i++)
////{
////    Console.WriteLine(customers[i].FirstName + " : " + expectedCustomers[i].FirstName);
////}



//Assert