
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mobile_application.Models
{
    public class F_hSefareshSeller
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CodeShobe { get; set; }
        public long sp_GetLatestAvailableSefareshHeaderCode_HeaderCode { get; set; }
        public string TarikhBarge { get; set; }
        public int CodeMoshtari { get; set; }
        public int CodeForooshande { get; set; }
        public int CodeMosavabe { get; set; }
        public int NoeTasvie { get; set; }
        public int ModdateTasvie { get; set; }
        public int sp_GetAvailableCustomerJob { set; get; }
        public long sp_GetLatestAvailableSefareshHeaderCode_HeaderSerial { get; set; }
        public int Supervisor { get; set; }
        public int CodeSupervisor { get; set; }
        public long CodeKarbar { get; set; }
        public string TarikheRooz { get; set; }

    }
}