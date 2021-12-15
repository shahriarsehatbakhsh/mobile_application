
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_customer_information
    {
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Shobe { get; set; }
		public int? CodeMoshtari { get; set; }
		public int? CodePishe { get; set; }
		public int? CodeOstan { get; set; }
		public string NameOstan { get; set; }
		public int? CodeShahr { get; set; }
		public string NameShahr { get; set; }
		public int? CodeMantaghe { get; set; }
		public string NameMantaghe { get; set; }
		public int? CodeMasir { get; set; }
		public string NameMasir { get; set; }
		public string Tell { get; set; }
		public string Mobile { get; set; }
		public string Address { get; set; }
		public string Message { get; set; }
	}
}
