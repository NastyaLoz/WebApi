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
                throw new SecurityException("There is no such session");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<SessionDto> GetSessionAsync(int sessionId)
        {
            var component = await Context.TSessions.SingleOrDefaultAsync(q=>q.sessionId == sessionId);
            if (component == null)
            {
                throw new SecurityException("There is no such session");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<SessionDto[]> GetSessionsByTypeAsync(int chargepoleId)
        {
            var component = await Context.TSessions.Where(q=>q.Deleted == false).Where(q=>q.chargepoleId == chargepoleId).ToArrayAsync();
            if (component == null)
            {
                throw new SecurityException("There is no such session");
            }
            // return component.ToJsonDto().OrderByDescending(q=>q.datetime).ToArray();
            return component.ToJsonDto().OrderByDescending(q=>q.order_date).ToArray();
        }
        
        ///////// Session /////////
        public async Task<ChargePoleDto[]> GetChargePolesAsync()
        {
            var component = await Context.TChargePoles.ToArrayAsync();
            if (component == null)
            {
                throw new SecurityException("There is no such session");
            }
            return component.ToJsonDto();
        }
        
        ///////// Session /////////
        public async Task<SessionDto> CreateSessionAsync(NewSessionDto component)
        {
            var newComponentType = Context.TChargePoles.SingleOrDefault(q => q.chargepoleId == component.chargepoleId);
            if (newComponentType == null)
            {
                throw new SecurityException("There is no such charge pole type");
            }
            
            var session = new TSessions
            {
                dt  = System.Convert.ToDateTime(component.dt),
                start = TimeSpan.Parse(component.start),
                stop = TimeSpan.Parse(component.stop),
                // chargePoleId = component.ChargePoleId,
                soc_final = Convert.ToInt16(component.much_charge / 60) + 20,
                soc_inittial = 20,
                battery_size = 60,
                smart = !component.smart,
                much_charge = component.much_charge,
                power = component.power,
                ChargePole = newComponentType,
                control_applyed = false,
                order_date = DateTime.Now,
                chargepoleId = component.chargepoleId
                
            };
            await Context.TSessions.AddAsync(session, CancellationToken);
            await Context.SaveChangesAsync(CancellationToken);
            return  session.ToJsonDto();
        }
        
        public async Task RemoveSessionAsync(int sessionId)
        {
            var session = Context.TSessions.Where(q=>q.Deleted == false).FirstOrDefault(q => q.sessionId == sessionId);
            if (session == null)
                throw new SecurityException("There is no such session");
            session.Deleted = true;
            await Context.SaveChangesAsync(CancellationToken);
        }
        
        public async Task<SessionDto> UpdateSessionAsync(NewSessionDto sessionDto)
        {
            var session = await Context.TSessions.Where(q=>q.Deleted == false).FirstOrDefaultAsync(q => q.sessionId == sessionDto.sessionId);
            if (session == null)
            {
                throw new SecurityException("There is no such session");
            }
            var newComponentType = Context.TChargePoles.SingleOrDefault(q => q.chargepoleId == sessionDto.chargepoleId);
            if (newComponentType == null)
            {
                throw new SecurityException("There is no such charge pole type");
            }

            session.sessionId = sessionDto.sessionId;
            session.dt = System.Convert.ToDateTime(sessionDto.dt);
            session.start = TimeSpan.Parse(sessionDto.start);
            session.stop= TimeSpan.Parse(sessionDto.stop);
            session.soc_final = Convert.ToInt16(sessionDto.much_charge / 60) + 20;
            session.soc_inittial = 20;
            session.battery_size = 60;
            session.smart = sessionDto.smart;
            session.much_charge = sessionDto.much_charge;
            session.power = sessionDto.power;
            session.ChargePole = newComponentType;
            session.control_applyed = sessionDto.control_applyed;
            session.order_date = DateTime.Now;
            session.chargepoleId = sessionDto.chargepoleId;
            await Context.SaveChangesAsync(CancellationToken);
            return session.ToJsonDto();
        }
    }
}