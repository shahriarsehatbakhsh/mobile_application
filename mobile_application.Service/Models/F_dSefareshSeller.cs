
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class F_dSefareshSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CodeShobe { get; set; }
        public long ShomareBarge_Header { get; set; }
        public int ShomareRadif { get; set; }
        public int CodeAnbaar { get; set; }
        public string CodeKala { get; set; }
        public decimal Meghdar { get; set; }
        public float Nerkh { get; set; }
        public decimal Mablagh { get; set; }
        public int NoeBaste { set; get; }
        public decimal TedadBaste { get; set; }
        public decimal TedadDarHarBaste { get; set; }
        public long CodeKarbar { get; set; }
        public string TarikhRooz { get; set; }
        public int BranchCode { get; set; }
        public string MoshtariCode { get; set; }
        public string NameKala { get; set; }
    }
}