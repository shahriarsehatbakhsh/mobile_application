
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace mobile_application.API.Models
{
    public class DB_Entities : DbContext
    {

        public DB_Entities(DbContextOptions<DB_Entities> options)
             : base(options)
        {
        }
        public DbSet<vw_api_customer_list> vw_api_customer_list { get; set; }

    }
}
