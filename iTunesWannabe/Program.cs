using iTunesWannabe.Models;
using iTunesWannabe.Repositories;

CustomerRepository getCustomerInfo = new CustomerRepository();


//getCustomerInfo.GetById(23);

getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Daan"));

//getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Marc"));