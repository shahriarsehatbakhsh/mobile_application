
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_customer_cart_result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal BalancePrice { get; set; }
        public decimal? SumDebtorPrice { get; set; }
        public decimal? SumCreditorPrice { get; set; }
    }
}