
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.API.Models
{
    public class vw_api_customer_list
    {
        [Key]
        public int Code { get; set; }
        public string? Sharh { get; set; }
        public int? Job { get; set; }
        public string? Address { get; set; }
        public string? Tel { get; set; }
        public Int16 Branch { get; set; }
    }
}
