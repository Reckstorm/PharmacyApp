using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyApp.Model
{
    class Context : DbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Category> Categories { get; set; } 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PharmacyAppDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public Context() { }
    }
}
