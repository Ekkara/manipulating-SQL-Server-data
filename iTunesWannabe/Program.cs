using iTunesWannabe.Models;
using iTunesWannabe.Repositories;
using System.Collections.Generic;


CustomerRepository customerRep = new();
Console.WriteLine(customerRep.GetAll().Count);
customerRep.UpdateElement(new Customer("Blastoise", "Tesson", "Test", "00000", "000 00 0000", "test@test.test"), 62);
Console.WriteLine(customerRep.GetAll().Count);