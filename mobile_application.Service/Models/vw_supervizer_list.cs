
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Service.Models
{
	public class vw_supervizer_list
	{
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Code { get; set; }
		public string Sharh { get; set; }
		public string Job { get; set; }
		public string Address { get; set; }
		public string Tel { get; set; }
		public short Branch { get; set; }
	}
}