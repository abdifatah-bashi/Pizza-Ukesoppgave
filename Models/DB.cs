using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Pizza_Ukesoppgave.Models
{
    public class DB: DbContext
    {

        public DB()
            : base ("name = Bestilling")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Kunde> Kunder { get; set; }

        public DbSet<Bestilling> Bestillinger { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}