using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWLDotNetCore.WinFormsApp;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = "LAPTOP-LF5BIQ5E",
        InitialCatalog = "DotNetTraining",
        UserID = "sa",
        Password = "twl@123",
        TrustServerCertificate = true
    };
}