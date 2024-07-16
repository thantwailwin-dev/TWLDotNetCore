﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWLDotNetCore.MinimalApi.Models;

namespace TWLDotNetCore.MinimalApi.Db
{
    public class AppDbContext : DbContext
    {
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
        }*/

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogModel> Blogs { get; set; }
    }
}
