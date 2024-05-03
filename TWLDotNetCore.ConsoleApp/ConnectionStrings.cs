using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWLDotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
         public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
         {
             DataSource = "LAPTOP-LF5BIQ5E", // server name
             InitialCatalog = "DotNetTraining", // database name
             UserID = "sa",
             Password = "twl@123"
         };
}
}
