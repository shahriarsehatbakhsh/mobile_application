
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_KalaPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        public string Sharh { get; set; }
        public decimal Value { get; set; }
        public int Type { get; set; }
    }
}