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
}