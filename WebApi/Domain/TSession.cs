using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int ChargePoleId { get; set; }
        public  bool smart { get; set; }
        public int much_charge { get; set; }
        public double power { get; set; }

        public virtual TChargePole ChargePole { get; set; }
    }
}