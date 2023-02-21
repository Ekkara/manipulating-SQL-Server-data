using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository customerRep = new();
Console.WriteLine(customerRep.GetHabitantsPerCountry());
//customerRep.PrintAllCustomerInfo(customerRep.SortCustomersByNationality());