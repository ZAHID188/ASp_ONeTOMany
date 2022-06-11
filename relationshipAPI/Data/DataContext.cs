﻿using Microsoft.EntityFrameworkCore;
using relationshipAPI.Model;

namespace relationshipAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> users { get; set; } 
        public DbSet<Charecter> Charecters { get; set; }
        public DbSet<weapon> weapons { get; set; }
        public DbSet<Skills> Skillls { get; set; }



    }
}
