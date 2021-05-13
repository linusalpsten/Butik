﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.DB
{
    public class ShoppingCartContext : DbContext
    {
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCartContext(DbContextOptions<ShoppingCartContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShoppingCartItem>().HasKey(sc => new { sc.CartId, sc.ItemId });
        }
    }
}
