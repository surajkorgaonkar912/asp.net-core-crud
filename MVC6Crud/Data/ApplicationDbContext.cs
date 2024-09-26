﻿using Microsoft.EntityFrameworkCore;
using MVC6Crud.Models;

namespace MVC6Crud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }       
    }
}
