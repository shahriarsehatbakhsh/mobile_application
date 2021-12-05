
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class vw_Users
    {
		[Key]
		[Column(Order = 0)]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int Use01 { get; set; }
		public string Use02 { get; set; }
		public string Use03 { get; set; }
		public int Use04 { get; set; }
		public string Use05 { get; set; }
		public int Use06 { get; set; }
		public int Use07 { get; set; }
		public int Use08 { get; set; }
		public string Use09 { get; set; }
		public string Use10 { get; set; }
		public string Use11 { get; set; }
		public int Use96 { get; set; }
		public int Use97 { get; set; }
		public int Use98 { get; set; }
		public string Use99 { get; set; }
		public string Use12 { get; set; }
		public string Use13 { get; set; }
		public int Use14 { get; set; }
		public string Use15 { get; set; }
		public int Use16 { get; set; }
	}
}