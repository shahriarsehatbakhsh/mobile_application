using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mobile_application.Service.Models;

namespace mobile_application.Service.Data
{
    public class MaliDBContext : DbContext
    {
        public MaliDBContext (DbContextOptions<MaliDBContext> options)
            : base(options)
        {
        }

        public DbSet<mobile_application.Service.Models.vw_code_sharh> vw_code_sharh { get; set; }

        public DbSet<mobile_application.Service.Models.vw_customers_list> vw_customers_list { get; set; }

        public DbSet<mobile_application.Service.Models.vw_seller_list> vw_seller_list { get; set; }

        public DbSet<mobile_application.Service.Models.vw_customer_code_serial> vw_customer_code_serial { get; set; }

        public DbSet<mobile_application.Service.Models.vw_supervizer_list> vw_supervizer_list { get; set; }

        public DbSet<mobile_application.Service.Models.ErrorResult> ErrorResult { get; set; }

        public DbSet<mobile_application.Service.Models.vw_GetLatestAvailableCustomerCode> vw_GetLatestAvailableCustomerCode { get; set; }

        public DbSet<mobile_application.Service.Models.vw_customer_cart_result> vw_customer_cart_result { get; set; }
        public DbSet<mobile_application.Service.Models.vw_Resault> vw_Resault { get; set; }
    }
}
