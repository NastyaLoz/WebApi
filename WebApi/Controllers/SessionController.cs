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
    public class SessionController
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

        [HttpGet("{chargepoleId}")]
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
    }
}