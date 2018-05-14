using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace M120Projekt.DAL
{
    class Context : DbContext
    {
        public Context() : base("name=M120Connectionstring")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DAL.Context, M120Projekt.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().ToTable("Reservationen"); // Damit kein "s" angehängt wird an Tabelle
            modelBuilder.Entity<Platz>().ToTable("Plaetze"); // Damit kein "s" angehängt wird an Tabelle
        }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Platz> Platz { get; set; }
    }
}
