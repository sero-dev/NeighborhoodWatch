using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NeighborhoodWatch.DAC.Entity;
using NeighborhoodWatch.DAC.Interface;
using NpgsqlTypes;

namespace Neighborhood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly ILogger<IncidentController> _logger;
        private readonly IIncidentRepository _incidentRepository;

        public IncidentController(IIncidentRepository incidentRepository, ILogger<IncidentController> logger)
        {
            _logger = logger;
            _incidentRepository = incidentRepository;
        }

        [HttpGet]
        public List<Incident> Get(string type)
        {
            if (type == null) return _incidentRepository.GetAll().ToList();
            return _incidentRepository.GetByType(type).ToList();
        }

        [HttpPost]
        public IActionResult Add(string type, string county, string state)
        {
            try
            {
                Incident newIncident = new Incident
                {
                    Type = type,
                    County = county,
                    State = state
                };

                return _incidentRepository.Add(newIncident) ? Ok() : StatusCode(500);
            }

            catch(Exception e)
            {
                _logger.LogError($"Invalid Values: {e.Message}");
                return BadRequest();
            }
            
        }


    }
}