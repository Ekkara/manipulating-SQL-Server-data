using iTunesWannabe.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace iTunesWannabe.Models
{
    public class Customer
    {
        public Customer(int? id, string? firstName, string? lastName, string? country, string? postalCode, string? phone, string? email)
        {
            this.CustmerID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Email = email;
        }
        public int? CustmerID { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Country { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (customer1.CustmerID != customer2.CustmerID) return false;
            if (customer1.FirstName != customer2.FirstName) return false;
            if (customer1.LastName != customer2.LastName) return false;
            if (customer1.Country != customer2.Country)  return false;
            if(customer1.PostalCode != customer2.PostalCode) return false;
            if(customer1.Phone != customer2.Phone) return false;
            if (customer1.Email != customer2.Email) return false;
            return true;
        }

        public static bool operator !=(Customer customer1, Customer customer2)
        {
            return !(customer1 == customer2);
        }
        public override string ToString()
        {
            return
            CustmerID + " "    
            + FirstName + "  "
            + LastName + "  "
            + Country + "  "
            + PostalCode + "  "
            + Phone + "  "
            + Email;
        }
    }
}

