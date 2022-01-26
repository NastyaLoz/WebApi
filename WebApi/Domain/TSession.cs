using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;
using WebApi.Models;

namespace WebApi.Domain
{
    [Table("Sessions", Schema = "dbo")]
    public partial class TSessions
    {
        [Key]
        public int sessionId { get; set; }
        public DateTime dt { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan stop { get; set; }
        public int soc_inittial { get; set; }
        public int soc_final { get; set; }
        public double battery_size { get; set; }
        
        public int chargepoleId { get; set; }
        public  bool smart { get; set; }
        public int much_charge { get; set; }
        public double power { get; set; }
        public bool control_applyed { get; set; }
        public DateTime order_date { get; set; }
        public virtual TChargePole ChargePole { get; set; }
        public bool Deleted { get; set; }
    }
}