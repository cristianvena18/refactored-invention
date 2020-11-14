﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpFinal.Models;

namespace TpFinal.Data
{
    public class DatabaseConnection : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Film> Films { get; set; }
    }
}
