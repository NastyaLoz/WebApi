using System;

namespace WebApi.Dto
{
    public class NewSessionDto
    {
        public int sessionId { get; set; }
        public string dt { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public int soc_inittial { get; set; }
        public int soc_final { get; set; }
        public double battery_size { get; set; }
        public int chargePoleId { get; set; }
        public  bool smart { get; set; }
        public int much_charge { get; set; }
        public double power { get; set; }
    }
}