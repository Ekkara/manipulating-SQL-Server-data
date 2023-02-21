using iTunesWannabe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesWannabe.Repositories
{
    public class CustomerRepository : ICustomers
    {
        private List<Customer> FetchCustomers(string sql)
        {
            List<Customer> allCustomers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionStringBuilder()))
                {
                    conn.Open();

                    //make command
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //handle result
                                allCustomers.Add(new Customer(
                                 reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                 reader.IsDBNull(1) ? "NULL" : reader.GetString(1),
                                 reader.IsDBNull(2) ? "NULL" : reader.GetString(2),
                                 reader.IsDBNull(3) ? "NULL" : reader.GetString(3),
                                 reader.IsDBNull(4) ? "NULL" : reader.GetString(4),
                                 reader.IsDBNull(5) ? "NULL" : reader.GetString(5),
                                 reader.IsDBNull(6) ? "NULL" : reader.GetString(6)));
                            }
                        }
                    }
                }
            }
            catch (SqlException error)
            {
                //failed
                Console.WriteLine("something went wrong: " + error);
            }
            return allCustomers;
        }

        private void EditCustomerDatabase(Customer customer, string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionStringBuilder()))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        if (cmd.ExecuteNonQuery() <= 0)
                        {
                            throw new Exception("could not add new customer " + customer.ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Customer> GetAll()
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return FetchCustomers(sql);
        }

        public void PrintAllCustomerInfo(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                PrintCustomerInfo(customers[i]);
            }
        }

        public void PrintCustomerInfo(Customer customer)
        {
            Console.WriteLine(customer.CustomerID + "  "
            + customer.FirstName + "  "
            + customer.LastName + "  "
            + customer.Country + "  "
            + customer.PostalCode + "  "
            + customer.Phone + "  "
            + customer.Email);
        }

        public Customer GetById(int id)
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return FetchCustomers(sql)[id - 1];
        }

        public List<Customer> GetAllByName(string name)
        {
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '%{name}%'";
            return FetchCustomers(sql);
        }

        public Customer GetOneByName(string name)
        {
            List<Customer> customers = GetAllByName(name);
            if (customers.Count <= 0) throw new Exception($"no customers found with the name {name}");
            return GetAllByName(name)[0];
        }

        public List<Customer> GetPage(int range, int offset)
        {
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerID OFFSET {offset} ROWS FETCH NEXT {range} ROWS ONLY;";
            return FetchCustomers(sql);
        }

        public void AddNewElement(Customer customer)
        {
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
              $"VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            EditCustomerDatabase(customer, sql);
        }

        public void UpdateElement(Customer customer, int idIndex)
        {
            string sql = "UPDATE Customer " +
                "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                $"WHERE CustomerId = {idIndex}";
         
            EditCustomerDatabase(customer, sql);
        }

        public string GetHabitantsPerCountry()
        {
            string sqlGetAll = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            List<Customer> allCustomers = FetchCustomers(sqlGetAll);

            Dictionary<string,int> inhabitants = new();
            

            for(int i = 0; i < allCustomers.Count; i++)
            {
                if (!inhabitants.ContainsKey(allCustomers[i].Country)) inhabitants.Add(allCustomers[i].Country, 1);
                else inhabitants[allCustomers[i].Country]++;
            }
            inhabitants = inhabitants.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            string rValue = "";
            foreach (string key in inhabitants.Keys)
            {
                rValue += key + " : " + inhabitants[key] + '\n';
            }

            return rValue;
        }
    }
}
