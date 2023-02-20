using iTunesWannabe.Models;
using iTunesWannabe.Repositories;

CustomerRepository getCustomerInfo = new CustomerRepository();

//getCustomerInfo.GetAllCustomerInfo(getCustomerInfo.GetAll());

//getCustomerInfo.GetById(23);

getCustomerInfo.PrintCustomerInfo(getCustomerInfo.GetByName("Marc"));