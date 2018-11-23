using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingCart_MVC.Models
{
    public class DatabaseContext : System.Data.Entity.DbContext
    {
        #region CTOR

        static DatabaseContext()
        {

            System.Data.Entity.Database.SetInitializer(
                new System.Data.Entity.CreateDatabaseIfNotExists<DatabaseContext>());

        }
        public DatabaseContext() : base("ShoppingCart_DB")
        {

        }

        #endregion

        #region Tables
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}