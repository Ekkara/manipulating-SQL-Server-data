using iTunesWannabe.Models;
using Microsoft.Data.SqlClient;
using System.Text;

namespace iTunesWannabe.Repositories
{    
    public class CustomerRepository : ICustomers
    {

        /// <summary>
        /// A generic function other more specifed function can call whenever they need to get customer(s).
        /// </summary>
        /// <param name="sql">define the search of customers</param>
        /// <param name="includeInvoice">A paraneter to set to true if we also want to see the amount of money a 
        /// customer have spent in the store. Not data always needed and would require extra data from the sql
        /// string, but not too unique to make it it's own function.</param>
        /// <returns>Returns a list of all costumers mathced with the sql query </returns>
        private List<Customer> FetchCustomers(string sql, bool includeInvoice = false)
        {
            //store all matching customer in this list
            List<Customer> allCustomers = new List<Customer>();
            try
            {
                //make connection to the server
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
                                //save all values
                                allCustomers.Add(
                                    new Customer(
                                 reader.IsDBNull(0) ? -1 : reader.GetInt32(0),
                                 reader.IsDBNull(1) ? "NULL" : reader.GetString(1),
                                 reader.IsDBNull(2) ? "NULL" : reader.GetString(2),
                                 reader.IsDBNull(3) ? "NULL" : reader.GetString(3),
                                 reader.IsDBNull(4) ? "NULL" : reader.GetString(4),
                                 reader.IsDBNull(5) ? "NULL" : reader.GetString(5),
                                 reader.IsDBNull(6) ? "NULL" : reader.GetString(6),
                                 includeInvoice ? reader.IsDBNull(7) ? -1 : reader.GetDecimal(7) : null));
                            }
                        }
                    }
                }
            }
            catch (SqlException error)
            {
                //failed, throwing an error
                throw new Exception("something went wrong: "  + error.Message);
            }

            if(allCustomers.Count <= 0)
            {
                throw new Exception("no matches found");
            }

            //return all values
            return allCustomers;
        }
        /// <summary>
        /// Alter the database in any way (not delete), how is specified in the sql parameter
        /// </summary>
        /// <param name="customer">sets (new) values for a customer</param>
        /// <param name="sql">instructs how to alter the database</param>
        /// <exception cref="Exception"></exception>
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
                            throw new Exception("could not make changes to " + customer.ToString());
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// A method to call upon whenever we want to fetch a list of all customers in the table, to use for iteration
        /// </summary>
        /// <returns>A list of all customers</returns>
        public List<Customer> GetAll()
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            return FetchCustomers(sql);
        }

        /// <summary>
        /// Quite literally, a method to print the info of all customers in the tablee
        /// </summary>
        /// <param name="customers">a list of customer to be displayed</param>
        public void PrintAllCustomerInfo(List<Customer> customers)
        {
            for (int i = 0; i < customers.Count; i++)
            {
                PrintCustomerInfo(customers[i]);
            }
        }

        /// <summary>
        /// Following, a method for printing the info of a single customer
        /// </summary>
        /// <param name="customer">Of the customer class, containing the data of customers corresponding to the columns of the customer table</param>
        public void PrintCustomerInfo(Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(customer.CustomerID + "  ");
            sb.Append(customer.FirstName + "  ");
            sb.Append(customer.LastName + "  ");
            sb.Append(customer.Country + "  ");
            sb.Append(customer.PostalCode + "  ");
            sb.Append(customer.Phone + "  ");
            sb.Append(customer.Email + "  ");
            if (customer.TotalSpent != null)
                sb.Append(customer.TotalSpent + "$");

            Console.WriteLine(sb);
        }

        /// <summary>
        /// A method for fetching a single customer by their ID. Useful for retrieving the same customer even if they undergo info changes.
        /// </summary>
        /// <param name="id">Fetching a customer through their id, without a parameter "int" id, is indeed challenging</param>
        /// <returns>It's gonna be either a customer, an elephant, or a motorcycle. Your guess.</returns>
        public Customer GetById(int id)
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email " +
            "   FROM Customer " +
            $"  WHERE CustomerId = {id}";

            //as the function returns a list but this function only need one element
            //we take the first (and only) element form the list
            return FetchCustomers(sql)[0];
        }

        /// <summary>
        /// If we have multiple people named Simba, we can retrieve them all by searching for the name Simba
        /// </summary>
        /// <param name="name">Simba. I mean name, for looking for Simba, I mean people with specific names</param>
        /// <returns>Simba, I mean all the customers sharing the same name</returns>
        public List<Customer> GetAllByName(string name)
        {
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer WHERE FirstName LIKE '%{name}%'";
            List<Customer> customers = FetchCustomers(sql);
            if (customers.Count <= 0) throw new Exception($"no customers found with the name {name}");
            return customers;
        }

        /// <summary>
        /// A method used for returning a single customer with the name equal to the input
        /// </summary>
        /// <param name="name">A string for searching for customers through a given name. In an alternate Earth, perhaps names are more common as ints</param>
        /// <returns>A single customer, probably with an extraordinarily ordinary name</returns>
        /// <exception cref="Exception">And if they don't exist in the table, they lucked out and found Spotify instead</exception>
        public Customer GetOneByName(string name)
        {
            return GetAllByName(name)[0];
        }

        /// <summary>
        /// If you'd ever need to retrieve a certain section of the customer table, this method is your guy. Or girl. Shan't assume a method's gender in 2023
        /// </summary>
        /// <param name="range">The amount of customers you want to retrieve</param>
        /// <param name="offset">From which id you want to start searching</param>
        /// <returns>A section of the customer table containing the data you asked for. </returns>
        public List<Customer> GetPage(int range, int offset)
        {
            string sql = $"SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer ORDER BY CustomerID OFFSET {offset - 1} ROWS FETCH NEXT {range} ROWS ONLY;";
            return FetchCustomers(sql);
        }

        /// <summary>
        /// The function that confirmed SSMS's temperament. It's supposed to add new elements to the customer table but honestly what do I know?
        /// </summary>
        /// <param name="customer">An input of all the data you want the new element to have. Trust me, you can even make a clone army</param>
        public void AddNewElement(Customer customer)
        {
            string sql = "INSERT INTO Customer(FirstName, LastName, Country, PostalCode, Phone, Email) " +
              $"VALUES(@FirstName, @LastName, @Country, @PostalCode, @Phone, @Email)";

            EditCustomerDatabase(customer, sql);
        }

        /// <summary>
        /// A method allowing you to alter data of any element in the customer table. Except ID. Because, you know, that'd defeat the point
        /// </summary>
        /// <param name="customer">Takes in new data for a customer, with any alterations wished upon them. Except ID</param>
        /// <param name="idIndex">We decide which customer to alter through their id</param>
        public void UpdateElement(Customer customer, int idIndex)
        {
            string sql = "UPDATE Customer " +
                "SET FirstName = @FirstName, LastName = @LastName, Country = @Country, PostalCode = @PostalCode, Phone = @Phone, Email = @Email " +
                $"WHERE CustomerId = {idIndex}";

            EditCustomerDatabase(customer, sql);
        }

        /// <summary>
        /// If you run this method, you'll see there lives about 13 people in all of the USA
        /// </summary>
        /// <returns>The number of people living in an entire country. Sweden's getting rather lonely</returns>
        public string GetHabitantsPerCountry()
        {
            string sql = "SELECT CustomerID, FirstName, LastName, Country, PostalCode, Phone, Email FROM Customer";
            List<Customer> allCustomers = FetchCustomers(sql);

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

        /// <summary>
        /// The saddest method. The method literally telling you to your face if you overspend on music in 2023.
        /// </summary>
        /// <returns>Customer data, plus their invoices in descending order from top to bottom. So basically a Hall of Shame</returns>
        public List<Customer> GetHighestSpenders()
        {
            //fetch all invoices
            string sql = "SELECT Customer.CustomerID, Customer.FirstName, Customer.LastName, Customer.Country, Customer.PostalCode, Customer.Phone, Customer.Email, SUM(Invoice.Total) as TotalSpent " +
                "FROM Invoice " +
                "JOIN Customer " +
                "ON Invoice.CustomerId = Customer.CustomerId " +
                "GROUP BY Customer.CustomerID, Customer.FirstName, Customer.LastName, Customer.Country, Customer.PostalCode, Customer.Phone, Customer.Email " +
                "ORDER BY TotalSpent DESC";

            return FetchCustomers(sql, true);
        }

        /// <summary>
        /// Displaying every customer's favorite genre, or genres in case they buy the same amount of multiple song types
        /// </summary>
        /// <param name="customerId">ID to decide which customer you specifically want to stalk</param>
        /// <returns>Fav genre</returns>
        public string GetMostPopularGenre(int customerId)
        {
            //A labyrinth of joins linking tables to the point where we can compare customer IDs to genre names.
            //I'm sure you had good fun imagining students Sherlock Holmesing their way through the DB to find this data. (>;_;)>
            string sql = 
                "SELECT TOP 1 PERCENT WITH TIES e.Name " +
                "FROM Invoice " +
                "JOIN (" +
                "    SELECT CustomerId " +
                "    FROM Customer " +
                $"    WHERE CustomerId = {customerId} " +
                ") AS a ON Invoice.CustomerId = a.CustomerId " +
                "JOIN InvoiceLine AS b ON Invoice.InvoiceId = b.InvoiceId " +
                "JOIN Track AS c ON b.TrackId = c.TrackId " +
                "JOIN Genre AS e ON c.GenreId = e.GenreId " +
                "GROUP BY e.GenreId, e.Name " +
                "ORDER BY COUNT(e.Name) DESC";

            List<string> favorites = new();
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
                                favorites.Add(reader.GetString(0));
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

            //return findings, different format depending on how many favurites were found
            if (favorites.Count == 1)
            {
                return "Favourite genre is " + favorites[0];
            }
            if (favorites.Count > 1)
            {
                string rValue = "Favourite genres are: ";
                foreach (string favurite in favorites)
                {
                    rValue += favurite + ", ";
                }
                rValue = rValue.Substring(0, rValue.Length - 2);
                return rValue;
            }
            return "No recorded purchases";
        }
    }
}
