
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_JobNo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JobNo { get; set; }
    }
}
