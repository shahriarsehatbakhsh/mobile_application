
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Service.Models
{
    public class vw_GetLatestAvailableCustomerCode
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerCode { set; get; }
        public string CustomerSerial { set; get; }

    }
}
