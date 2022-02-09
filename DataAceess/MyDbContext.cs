using Microsoft.EntityFrameworkCore;
using Projecta.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projecta.DataAceess
{
    public class MyDbContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }

        public MyDbContext()
        {
            Loans = this.Set<Loan>();

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS01;Database=sasDB;Trusted_Connection=True;");
        }
    }
}
