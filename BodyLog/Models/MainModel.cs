using BodyLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class DefaultConnection : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Dishes>  Dishes { get; set; }
    public DbSet<Dishes_Products> Dishes_Products { get; set; }

    public System.Data.Entity.DbSet<BodyLog.Models.Weights> Weight { get; set; }
}