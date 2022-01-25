using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Domain
{
    [Table("ChargePoles", Schema = "dbo")]
    public partial class TChargePole
    {
        [Key]
        public int chargepoleId { get;set; }
        public string power_source { get; set; }
        public string power_level { get; set; }
        public bool cost_optimization { get; set; }
        public bool charging_time { get; set; }
        public string name { get; set; }
        
        public virtual ICollection<TSessions> TSessions { get; set; }
    }
}