
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Service.Models
{
    public class vw_header_CodeSerial
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public decimal HeaderCode { get; set; }
        public decimal HeaderSerial { get; set; }
    }
}
