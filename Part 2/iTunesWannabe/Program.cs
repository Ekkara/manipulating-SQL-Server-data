using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository cr = new();
cr.PrintAllCustomerInfo(cr.GetPage(100000, -2));
