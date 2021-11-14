using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class testContext : DbContext
    {
        public testContext (DbContextOptions<testContext> options)
            : base(options)
        {
        }

        public DbSet<test.Models.Model1> Model1 { get; set; }
    }
}
