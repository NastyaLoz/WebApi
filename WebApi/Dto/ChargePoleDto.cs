namespace WebApi.Dto
{
    public class ChargePoleDto
    {
        public int chargepoleId { get;set; }
        public string power_source { get; set; }
        public string power_level { get; set; }
        public bool cost_optimization { get; set; }
        public bool charging_time { get; set; }
        public string name { get; set; }
    }
}