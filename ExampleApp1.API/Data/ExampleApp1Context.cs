using ExampleApp1.API.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExampleApp1.API.Data
{
    public class ExampleApp1Context : DbContext
    {
        public ExampleApp1Context(DbContextOptions<ExampleApp1Context> options) : base(options)
        {
            
        }

        public DbSet<Stock> Stocks { get; set; }

      


      
    }
}
