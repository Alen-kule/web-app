using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Web.Entities.Models.Sifarnik;

namespace Web.Entities.Models
{
    public class Context : DbContext
    {
        public Context() : base("conn")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<SifCharge> SifCharges { get; set; }
        public DbSet<SifCity> SifCities { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }

        //protected override void OnModelCreating(ModuleBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Client>().Property(s => s.Aktivna).HasDefaultValueSql("1");




        //}


    }

   
}