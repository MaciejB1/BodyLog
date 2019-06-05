﻿using BodyLog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

public class MainDB : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Dishes>  Dishes { get; set; }
    public DbSet<Dishes_Products> Dishes_Products { get; set; }
    public DbSet<Body> Body { get; set; }
    public DbSet<Training_PlansModel> Training_PlansModels { get; set; }
    public DbSet<Activities> Activities { get; set; }
}