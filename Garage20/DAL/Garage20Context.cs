using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Garage20.Models;

namespace Garage20.DAL
{
    public class Garage20Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Garage20Context() : base("name=Garage20Context")
        {
        }

        public DbSet<Fordon> Fordons { get; set; }
    }
}
