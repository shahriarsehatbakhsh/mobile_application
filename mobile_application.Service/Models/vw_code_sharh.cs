
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_code_sharh
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short Code { get; set; }
        public string Sharh { get; set; }
    }
}