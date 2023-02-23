namespace iTunesWannabe.Models
{
    public class Customer
    {
        public Customer(int? id, string? firstName, string? lastName, string? country, string? postalCode, string? phone, string? email, decimal? moneySpent = 0)
        {
            this.CustomerID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Email = email;
            this.TotalSpent = moneySpent;
        }
        public Customer(string? firstName, string? lastName, string? country, string? postalCode, string? phone, string? email, decimal? moneySpent = 0)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
            this.PostalCode = postalCode;
            this.Phone = phone;
            this.Email = email;
            this.TotalSpent = moneySpent;
        }


        public int? CustomerID { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Country { get; private set; }
        public string? PostalCode { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public decimal? TotalSpent { get; private set; }

        public static bool operator ==(Customer customer1, Customer customer2)
        {
            if (customer1.CustomerID != customer2.CustomerID) return false;
            if (customer1.FirstName != customer2.FirstName) return false;
            if (customer1.LastName != customer2.LastName) return false;
            if (customer1.Country != customer2.Country) return false;
            if (customer1.PostalCode != customer2.PostalCode) return false;
            if (customer1.Phone != customer2.Phone) return false;
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
            CustomerID + " "
            + FirstName + "  "
            + LastName + "  "
            + Country + "  "
            + PostalCode + "  "
            + Phone + "  "
            + Email;
        }
    }
}

