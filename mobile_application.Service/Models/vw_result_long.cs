
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_result_long
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long? result { get; set; }
    }
}