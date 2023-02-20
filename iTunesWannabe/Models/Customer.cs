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
    }
}

