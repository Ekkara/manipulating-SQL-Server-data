using iTunesWannabe.Models;
using Microsoft.Data.SqlClient;
using System;
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
        public List<Customer> GetAll()
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return FetchCustomers(sql);
        }

        public void GetAllCustomerInfo(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                PrintCustomerInfo(customers[i]);
            }
        }

        public void PrintCustomerInfo(Customer customer)
        {
            Console.WriteLine(customer.CustmerID + "  "
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
            bool success = false;
            string sql = "INSERT INTO Customer(CustomerId, FirstName, LastName, Country, PostalCode, Phone, Email) " +
                $"VALUES({customer.CustmerID}, {customer.FirstName},{customer.LastName},{customer.Country},{customer.PostalCode},{customer.Phone},{customer.Email});";

            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionStringBuilder()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerId", customer.CustmerID);
                        cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                        cmd.Parameters.AddWithValue("@Country", customer.Country);
                        cmd.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
                        cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                        cmd.Parameters.AddWithValue("@Email", customer.Email);

                        success = cmd.ExecuteNonQuery() > 0 ? true : false;
                        if (!success)
                        {
                            throw new Exception("could not add new customer " + customer.ToString());
                        }
                    }
                }
            }
            catch
            {

            }
        }
    }
}
