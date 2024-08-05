/*using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWLDotNetCore.RestApi.Models;
using TWLDotNetCore.RestApiWithNLayer;*/

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TWLDotNetCore.PizzaOrder.Models;

namespace TWLDotNetCore.PizzaOrder.Db
{
    internal class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }
        public DbSet<PizzaModel> Pizzas { get; set; }        
        public DbSet<PizzaExtraModel> Extras { get; set; }        
        public DbSet<PizzaOrderModel> Orders { get; set; }        
        public DbSet<PizzaOrderDetailModel> OrderDetails { get; set; }        
    }    

}
