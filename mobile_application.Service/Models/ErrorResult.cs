
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Service.Models
{
    public class ErrorResult
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ErrorNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
}