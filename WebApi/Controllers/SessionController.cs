using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Domain;
using WebApi.Dto;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("sessions")]
    public class SessionController: ControllerBase
    {
        
        private readonly ISessionRepository _sessionRepository;

        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        
        ///////// Component /////////
        /// <summary>
        /// Взять все Component
        /// </summary>
        /// <returns></returns>

        [HttpGet("")]
        public async Task<ActionResult<SessionDto[]>> GetComponents()
        {
            var res = await _sessionRepository.GetSessionsAsync();
            return res;
        }
        
        ///////// Component /////////
        /// <summary>
        /// Взять все Component
        /// </summary>
        /// <returns></returns>

        [HttpGet("chargepoleId={chargepoleId}")]
        public async Task<ActionResult<SessionDto[]>> GetSessionsByTypeAsync(int chargepoleId)
        {
            var res = await _sessionRepository.GetSessionsByTypeAsync(chargepoleId);
            return res;
        }
        ///////// Component /////////
        /// <summary>
        /// Взять все Component
        /// </summary>
        /// <returns></returns>

        [HttpGet("chargepole")]
        public async Task<ActionResult<ChargePoleDto[]>> GetChargePolesAsync()
        {
            var res = await _sessionRepository.GetChargePolesAsync();
            return res;
        }
        
        /// <summary>
        /// Создадим новый Component
        /// </summary>
        /// <returns></returns>
        [HttpPost("newSession")]
        public async Task<SessionDto> CreateComponentAsync([FromBody]NewSessionDto component)
        {
            var result = await _sessionRepository.CreateSessionAsync(component);
            return result;

        }
        
        /// <summary>
        /// Удаление Component по id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("remove/{sessionId}")]
        public async Task<StatusCodeResult> RemoveSessionAsync(int sessionId)
        {
            await _sessionRepository.RemoveSessionAsync(sessionId);
            return NoContent();
        }
        
        /// <summary>
        /// Обновление Component по id
        /// </summary>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<SessionDto> UpdateComponentAsync([FromBody] NewSessionDto sessionDto)
        {
            var result = await _sessionRepository.UpdateSessionAsync(sessionDto);
            return result;

        }
        
        /// <summary>
        /// Взять Component по его id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{sessionId}")]
        public async Task<ActionResult<SessionDto>> GetSession(int sessionId)
        {
            var result = await _sessionRepository.GetSessionAsync(sessionId);
            if (result != null)
                return result;
            return NoContent();
        }
    }
}