using iTunesWannabe.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
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
        private List<Invoice> FetchInvoices(string sql)
        {
            List<Invoice> allInvoices = new List<Invoice>();
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
                            double a = -1.0;
                            while (reader.Read())
                            {
                                //handle result
                                allInvoices.Add(new Invoice(
                                 reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                 (reader.IsDBNull(1) ? -1 : reader.GetDecimal(1))));
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
            return allInvoices;
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

        public void PrintAllCustomerInfo(List<Customer> customers, bool displayInvoice = false)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                PrintCustomerInfo(customers[i], displayInvoice);
            }
        }

        public void PrintCustomerInfo(Customer customer, bool displayInvoice = false)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(customer.CustomerID + "  ");
            sb.Append(customer.FirstName + "  ");
            sb.Append(customer.LastName + "  ");
            sb.Append(customer.Country + "  ");
            sb.Append(customer.PostalCode + "  ");
            sb.Append(customer.Phone + "  ");
            sb.Append(customer.Email + "  ");
            if(displayInvoice)
                sb.Append(customer.TotalSpent + "$");

            Console.WriteLine(sb);
        }

        public Customer GetById(int id)
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return FetchCustomers(sql)[id - 1];
            //todo do this with sql
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

            Dictionary<string, int> inhabitants = new();


            for (int i = 0; i < allCustomers.Count; i++)
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

        //todo: use join
        public List<Customer> GetHighestSpenders()
        {
            //fetch all invoices
            string sql = "SELECT CustomerId, Total FROM Invoice";
            List<Invoice> invoices = FetchInvoices(sql);
            Dictionary<int, decimal> customerToInvoice = new();

            //combine all users invoices
            for(int i = 0; i < invoices.Count; i++)
            {
                if (customerToInvoice.ContainsKey(invoices[i].CustomerId)) { customerToInvoice[invoices[i].CustomerId] += invoices[i].Total; }
                else customerToInvoice.Add(invoices[i].CustomerId, invoices[i].Total);
            }


            //sort top to lowest
            customerToInvoice = customerToInvoice.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            //find customer from sorted dictionary of higest spenders
            List<Customer> result = new();

            foreach(int id in customerToInvoice.Keys)
            {
                result.Add(new Customer(GetById(id), customerToInvoice[id]));
            }
            return result;
        }

        //For a given customer, their most popular genre (in the case of a tie, display both). Most popular in this context
        //means the genre that corresponds to the most tracks from invoices associated to that customer.
        public string GetMostPopularGenre(int customerId)
        {
            //(invoice) ->InvoiceId -> (InvoiceLine) -> trackId-> (Track) -> GenereId -> (Genre) -> Genre 
            string sqlGetCustomerWithID =
                $"SELECT DISTINCT e.Name, a.CustomerId, b.InvoiceId, c.TrackId, d.GenreId\r\nFROM Invoice\r\nJOIN (\r\n    SELECT CustomerId\r\n    FROM Customer\r\n    WHERE CustomerId = {customerId}\r\n) AS a ON Invoice.CustomerId = a.CustomerId\r\nJOIN(\r\n    SELECT InvoiceId\r\n    FROM InvoiceLine\r\n) AS b ON  Invoice.InvoiceId = b.InvoiceId\r\nJOIN(\r\n    SELECT TrackId, InvoiceId\r\n    FROM InvoiceLine\r\n) AS c ON  Invoice.InvoiceId = c.InvoiceId\r\nJOIN(\r\n    SELECT TrackId, GenreId\r\n    FROM Track\r\n) AS d ON  c.TrackId = d.TrackId\r\nJOIN(\r\n    SELECT Name, GenreId\r\n    FROM Genre\r\n) AS e ON  d.GenreId = e.GenreId";

            Dictionary<string, int> genreToAmount = new();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionStringHelper.GetConnectionStringBuilder()))
                {
                    conn.Open();

                    //make command
                    using (SqlCommand cmd = new SqlCommand(sqlGetCustomerWithID, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            string key;
                            while (reader.Read())
                            {
                                key = reader.GetString(0);
                                if (genreToAmount.ContainsKey(key)) genreToAmount[key]++;
                                else genreToAmount.Add(key, 1);
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
            genreToAmount = genreToAmount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            //add genres to favorites
            int lastAmount = 0;
            List<string> favorites = new();
            foreach(string key in genreToAmount.Keys)
            {
                if (genreToAmount[key] >= lastAmount)
                {
                    favorites.Add(key);
                    lastAmount = genreToAmount[key];
                }
                else
                {
                    break;
                }
            }

            //build string that reveals if it is a favorite or not
            string rValue = "";
            if(favorites.Count == 1)
            {
                rValue = "Favorite genre is: " + favorites[0];
            }
            else if(favorites.Count > 1) 
            {
                rValue = "Favourites genres are: ";
                foreach(string genre in favorites)
                {
                    rValue += genre + ", ";
                }
                rValue = rValue.Substring(0, rValue.Length - 2);
            }
            return rValue;
        }
    }
}
