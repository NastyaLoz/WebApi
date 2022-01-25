using System.Collections.Generic;
using System.Linq;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Extensions
{
    public static class SessionExtensions
    {
        public static SessionDto ToJsonDto(this TSessions session)
        {
            return new SessionDto
            {
                sessionId = session.sessionId,
                dt  = session.dt,
                start = session.start,
                stop = session.stop,
                chargePoleId = session.ChargePoleId,
                soc_final = session.soc_final,
                soc_inittial = session.soc_inittial,
                battery_size = session.battery_size,
                smart = session.smart,
                much_charge = session.much_charge,
                power = session.power
            };
        }
        
        public static SessionDto[] ToJsonDto(this IEnumerable<TSessions> components)
        {
            return components.Select(at => at.ToJsonDto()).ToArray();
        }
    }
}