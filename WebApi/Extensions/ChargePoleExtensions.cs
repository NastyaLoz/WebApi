using System.Collections.Generic;
using System.Linq;
using WebApi.Domain;
using WebApi.Dto;

namespace WebApi.Extensions
{
    public static class ChargePoleExtensions
    {
        public static ChargePoleDto ToJsonDto(this TChargePole chargePole)
        {
            return new ChargePoleDto
            {
                chargepoleId = chargePole.chargepoleId,
                power_level = chargePole.power_level,
                power_source = chargePole.power_source,
                cost_optimization = chargePole.cost_optimization,
                name = chargePole.name,
                charging_time = chargePole.charging_time
            };
        }
        
        public static ChargePoleDto[] ToJsonDto(this IEnumerable<TChargePole> chargePoles)
        {
            return chargePoles.Select(at => at.ToJsonDto()).ToArray();
        }
    }
}