using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository customerRep = new();
Console.WriteLine(customerRep.GetAll().Count);
customerRep.AddNewElement(new Customer("Test", "Tesson", "Test", "00000", "000 00 0000", "test@test.test"));
Console.WriteLine(customerRep.GetAll().Count);