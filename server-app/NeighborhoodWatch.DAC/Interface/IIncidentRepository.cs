using NeighborhoodWatch.DAC.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeighborhoodWatch.DAC.Interface
{
    public interface IIncidentRepository
    {
        IQueryable<Incident> GetByType(string type);
        IQueryable<Incident> GetAll();
        bool Add(Incident newIncident);
    }
}
