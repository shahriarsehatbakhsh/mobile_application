using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mobile_application.Models;

namespace mobile_application.Service.Data
{
    public class MaliDBContext : DbContext
    {
        public MaliDBContext (DbContextOptions<MaliDBContext> options)
            : base(options)
        {
        }

        public DbSet<mobile_application.Models.vw_code_sharh> vw_code_sharh { get; set; }
        public DbSet<mobile_application.Models.vw_KalaPackage> vw_KalaPackage { get; set; }
        public DbSet<mobile_application.Models.vw_customers_list> vw_customers_list { get; set; }
        public DbSet<mobile_application.Models.vw_seller_list> vw_seller_list { get; set; }
        public DbSet<mobile_application.Models.vw_customer_code_serial> vw_customer_code_serial { get; set; }
        public DbSet<mobile_application.Models.vw_supervizer_list> vw_supervizer_list { get; set; }
        public DbSet<mobile_application.Models.ErrorResult> ErrorResult { get; set; }
        public DbSet<mobile_application.Models.vw_GetLatestAvailableCustomerCode> vw_GetLatestAvailableCustomerCode { get; set; }
        public DbSet<mobile_application.Models.vw_customer_cart_result> vw_customer_cart_result { get; set; }
        public DbSet<mobile_application.Models.vw_result> vw_result { get; set; }
        public DbSet<mobile_application.Models.vw_result_long> vw_result_long { get; set; }
        public DbSet<mobile_application.Models.vw_header_CodeSerial> vw_header_CodeSerial { get; set; }
        public DbSet<mobile_application.Models.vw_JobNo> vw_JobNo { get; set; }
    }
}
