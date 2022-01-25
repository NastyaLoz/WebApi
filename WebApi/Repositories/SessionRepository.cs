using System;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using WebApi.Domain;
using Microsoft.EntityFrameworkCore;
using WebApi.Dto;
using WebApi.Extensions;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class SessionRepository:EfRepository, ISessionRepository
    {
        public SessionRepository(IApplicationDbContext context, ICalcellationTokenProvider cancellationTokenProvider) : base(context, cancellationTokenProvider)
        {
        }
        
        ///////// Session /////////
        public async Task<SessionDto[]> GetSessionsAsync()
        {
            var component = await Context.TSessions.ToArrayAsync();
            if (component == null)
            {
                throw new SecurityException("There is no such component");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<SessionDto[]> GetSessionsByTypeAsync(int chargepoleId)
        {
            var component = await Context.TSessions.Where(q=>q.ChargePoleId == chargepoleId).ToArrayAsync();
            if (component == null)
            {
                throw new SecurityException("There is no such component");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<ChargePoleDto[]> GetChargePolesAsync()
        {
            var component = await Context.TChargePoles.ToArrayAsync();
            if (component == null)
            {
                throw new SecurityException("There is no such component");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<SessionDto> CreateSessionAsync(NewSessionDto component)
        {
            var newComponentType = Context.TChargePoles.SingleOrDefault(q => q.chargepoleId == component.chargePoleId);
            if (newComponentType == null)
            {
                throw new SecurityException("There is no such componentType");
            }
            var t = System.Convert.ToDateTime(component.dt);
            var f = component.much_charge / 60;
            var session = new TSessions
            {
                dt  = System.Convert.ToDateTime(component.dt),
                start = TimeSpan.Parse(component.start),
                stop = TimeSpan.Parse(component.stop),
                // chargePoleId = component.ChargePoleId,
                soc_final = Convert.ToInt16(f) + 20,
                soc_inittial = 20,
                battery_size = 60,
                smart = component.smart,
                much_charge = component.much_charge,
                power = component.power,
                ChargePole = newComponentType
            };
            await Context.TSessions.AddAsync(session, CancellationToken);
            await Context.SaveChangesAsync(CancellationToken);
            return  session.ToJsonDto();
        }
    }
}