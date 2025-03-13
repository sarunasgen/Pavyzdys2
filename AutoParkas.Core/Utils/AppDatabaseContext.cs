using AutoParkas.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoParkas.Core.Utils
{
    public class AppDatabaseContext : DbContext
    {
        public DbSet<Automobilis> Automobiliai { get; set; }
        public DbSet<Klientas> Klientai { get; set; }
        public AppDatabaseContext(DbContextOptions<AppDatabaseContext> options) : base(options)
        {
            
        }
    }
}
