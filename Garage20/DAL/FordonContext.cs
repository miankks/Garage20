using Garage20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2._5.DAL
{

    public class FordonContext : DbContext
    {
        public FordonContext() : base("FordonContext") { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new FordonContextInitializer());
        //    base.OnModelCreating(modelBuilder);
        //}

        public DbSet<Fordon> Fordon { get; set; }
        public DbSet<Medlem> Medlemmar { get; set; }
        public DbSet<Fordonstyp> Fordonstyp { get; set; }
    }

}