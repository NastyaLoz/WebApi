using System;
namespace WebApi.Models
{
    public class Session
    {
        public int sessionId { get; set; }
        public DateTime dt { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan stop { get; set; }
        public ChargePole chargePole { get; set; }
        public bool smart { get; set; }
    }
}