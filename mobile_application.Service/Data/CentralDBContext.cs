using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Models;

namespace mobile_application.Service.Data
{
    public class CentralDBContext : DbContext
    {
        public CentralDBContext(DbContextOptions<CentralDBContext> options)
            : base(options)
        {
        }

        public DbSet<mobile_application.Service.Models.vw_result> vw_result { get; set; }
    }
}