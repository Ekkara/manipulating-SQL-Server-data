using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository customerRep = new();
customerRep.SortCustomersByNationality();
//customerRep.PrintAllCustomerInfo(customerRep.SortCustomersByNationality());