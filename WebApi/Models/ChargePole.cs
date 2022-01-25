namespace WebApi.Models
{
    public class ChargePole
    {
        public int chargepoleId { get;set; }
        public string power_source { get; set; }
        public int power_level { get; set; }
        public bool cost_optimization { get; set; }
        public bool charging_time { get; set; }
        public string name { get; set; }
    }
}