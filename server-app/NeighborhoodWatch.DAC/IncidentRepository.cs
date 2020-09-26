using Microsoft.Extensions.Logging;
using NeighborhoodWatch.DAC.Context;
using NeighborhoodWatch.DAC.Entity;
using NeighborhoodWatch.DAC.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeighborhoodWatch.DAC
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly IncidentContext _dbContext;

        public IncidentRepository(IncidentContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IQueryable<Incident> GetByType(string type)
        {
            return _dbContext.Incident.Where(i => i.Type.ToLower() == type.ToLower());
        }

        public bool Add(Incident newIncident) 
        {
            try
            {
                _dbContext.Incident.Add(newIncident);
                _dbContext.SaveChanges();
                return true;
            }

            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public IQueryable<Incident> GetAll()
        {
            return _dbContext.Incident;
        }
    }
}
