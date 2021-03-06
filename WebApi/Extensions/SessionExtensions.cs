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
                chargepoleId = session.chargepoleId,
                soc_final = session.soc_final,
                soc_inittial = session.soc_inittial,
                battery_size = session.battery_size,
                smart = session.smart,
                much_charge = session.much_charge,
                power = session.power,
                control_applyed = session.control_applyed,
                order_date = session.order_date,
                Deleted = session.Deleted
            };
        }
        
        public static SessionDto[] ToJsonDto(this IEnumerable<TSessions> components)
        {
            return components.Select(at => at.ToJsonDto()).ToArray();
        }
    }
}