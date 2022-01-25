using System;
using WebApi.Models;

namespace WebApi.Dto
{
    public class SessionDto
    {
        public int sessionId { get; set; }
        public DateTime dt { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan stop { get; set; }
        public DateTime datetime => dt + start;
        public int soc_inittial { get; set; }
        public int soc_final { get; set; }
        public double battery_size { get; set; }
        public int chargePoleId { get; set; }
        public  bool smart { get; set; }
        public int much_charge { get; set; }
        public double power { get; set; }
        public bool control_applyed { get; set; }
    }
}