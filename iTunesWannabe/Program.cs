using iTunesWannabe.Models;
using iTunesWannabe.Repositories;

CustomerRepository getCustomerInfo = new CustomerRepository();


//getCustomerInfo.GetById(23);

foreach(Customer co in getCustomerInfo.GetPage(500, 10))
{
    Console.WriteLine(co.FirstName);
}
//getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Daan"));

//getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Marc"));