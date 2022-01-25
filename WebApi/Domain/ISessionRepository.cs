using System.Threading.Tasks;
using WebApi.Dto;

namespace WebApi.Domain
{
    public interface ISessionRepository
    {
       Task<SessionDto[]> GetSessionsAsync();
       Task<SessionDto[]> GetSessionsByTypeAsync(int chargepoleId);
       Task<ChargePoleDto[]> GetChargePolesAsync();
       Task<SessionDto> CreateSessionAsync(NewSessionDto component);
    }
}