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
            /*try
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
                                Customer temp = new Customer(
                                 reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                 reader.IsDBNull(1) ? "NULL" : reader.GetString(1),
                                 reader.IsDBNull(2) ? "NULL" : reader.GetString(2),
                                 reader.IsDBNull(3) ? "NULL" : reader.GetString(3),
                                 reader.IsDBNull(4) ? "NULL" : reader.GetString(4),
                                 reader.IsDBNull(5) ? "NULL" : reader.GetString(5),
                                 reader.IsDBNull(6) ? "NULL" : reader.GetString(6));
                                allCustomers.Add(temp);
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

            return allCustomers.ElementAt(id - 1);*/
        }

        public List<Customer> GetAllCustomersByName(string name)
        {
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '%{name}%'";
            return FetchCustomers(sql);
        }
        public Customer GetOneCustomerByName(string name)
        {
            List<Customer> customers = GetAllCustomersByName(name);
            if (customers.Count <= 0) throw new Exception($"no customers found with the name {name}");
            return GetAllCustomersByName(name)[0];
        }

        public List<Customer> GetPage(int range, int offset)
        {
            List<Customer> allCustomers = new List<Customer>();
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerID OFFSET {offset} ROWS FETCH NEXT {range} ROWS ONLY;";

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
                                Customer temp = new Customer(
                                 reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                 reader.IsDBNull(1) ? "NULL" : reader.GetString(1),
                                 reader.IsDBNull(2) ? "NULL" : reader.GetString(2),
                                 reader.IsDBNull(3) ? "NULL" : reader.GetString(3),
                                 reader.IsDBNull(4) ? "NULL" : reader.GetString(4),
                                 reader.IsDBNull(5) ? "NULL" : reader.GetString(5),
                                 reader.IsDBNull(6) ? "NULL" : reader.GetString(6));
                                allCustomers.Add(temp);
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
            //connect
            return allCustomers;
        }

        
        /*
        List<Customer> customers = new List<Customer>();
        CustomerRepository customerRep = new();

        //Act
        customers = customerRep.GetAll();

        for(int i = 0;i<customers.Count; i++)
        {
            Console.WriteLine(customers[i].CustmerID);
        } */
    }
}
