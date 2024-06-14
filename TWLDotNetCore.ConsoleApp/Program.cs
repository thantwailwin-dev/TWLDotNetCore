
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using TWLDotNetCore.ConsoleApp.AdoDotNetExamples;
using TWLDotNetCore.ConsoleApp.DapperExamples;
using TWLDotNetCore.ConsoleApp.EFCoreExamples;
using TWLDotNetCore.ConsoleApp.Service;

Console.WriteLine("Hello, World!");

/*SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "LAPTOP-LF5BIQ5E";
stringBuilder.InitialCatalog = "DotNetTraining";
stringBuilder.UserID = "sa";
stringBuilder.Password = "twl@123";
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();


string query = "select * from Tbl_Blog";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);

connection.Close();

// DataSet => DataTable
// DataTable => DataRow
// DataRow => DataColumn

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id => " + dr["BlogId"]);
    Console.WriteLine("Blog Title => " + dr["BlogTitle"]);
    Console.WriteLine("Blog Author=> " + dr["BlogAuthor"]);
    Console.WriteLine("Blog Content => " + dr["BlogContent"]);
    Console.WriteLine("------------------------------------");
}*/

/*AdoDotNetExample adoDotNetExample = new AdoDotNetExample();*/
/*adoDotNetExample.Read()*/;
/*adoDotNetExample.Create("title", "author", "content");*/
/*adoDotNetExample.Update(16, "test title", "test author", "test content");*/
/*adoDotNetExample.Delete(13);*/
/*adoDotNetExample.Edit(2);*/

/*DapperExample dapperExample = new DapperExample();
dapperExample.Run();*/

/*EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();*/

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);

var serviceProvider = new ServiceCollection()  
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder)) 
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    }) 
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

/*AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();*/

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

/*var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
dapperExample.Run();*/

Console.ReadKey();