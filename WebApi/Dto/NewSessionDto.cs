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
        public int chargepoleId { get; set; }
        public  bool smart { get; set; }
        public int much_charge { get; set; }
        public double power { get; set; }
        public bool control_applyed { get; set; }
        public DateTime order_date { get; set; }
        public bool Deleted { get; set; }
    }
}