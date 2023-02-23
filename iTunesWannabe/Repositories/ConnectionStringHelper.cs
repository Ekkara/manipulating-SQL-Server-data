using Microsoft.Data.SqlClient;
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

namespace iTunesWannabe.Repositories
{
    public class ConnectionStringHelper
    {
        /// <summary>
        /// Generates the string used to create and manipulate the sql server database 
        /// </summary>
        /// <returns>return the genereated string</returns>
        public static string GetConnectionStringBuilder()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = "N-SE-01-6212\\SQLEXPRESS";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity = true;
            connectionStringBuilder.TrustServerCertificate = true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
