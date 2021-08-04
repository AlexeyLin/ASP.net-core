using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsManager.DAL.Interfaces;
using MetricsManager.DAL.Models;
using MetricsManager.Responses;
using Microsoft.Extensions.Logging;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly IAgentsRepository _repository;

        private readonly ILogger<AgentsController> _logger;

        private readonly IMapper _mapper;

        public AgentsController(ILogger<AgentsController> logger, IAgentsRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("list-agents")]
        public IActionResult GetListRegisterAgents()
        {
            var metrics = _repository.GetListRegisterAgents();

            var response = new AllAgentInfoResponse()
            {
                Metrics = new List<AgentInfoDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<AgentInfoDto>(metric));
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public IActionResult RegisterAgent([FromBody] AgentInfo agentInfo)
        {
            _repository.RegisterAgent(new AgentInfo
            {
                Id = agentInfo.Id,
                Address = agentInfo.Address
            });
            return Ok();
        }

        [HttpPut("enable/{agentId}")]
        public IActionResult EnableAgentById([FromRoute] int agentId)
        {
            _repository.EnableAgentById(agentId);
            return Ok();
        }

        [HttpPut("disable/{agentId}")]
        public IActionResult DisableAgentById([FromRoute] int agentId)
        {
            _repository.DisableAgentById(agentId);
            return Ok();
        }
    }
}
