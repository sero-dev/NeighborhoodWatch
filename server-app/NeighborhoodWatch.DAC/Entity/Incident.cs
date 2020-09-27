using System;
using System.Collections.Generic;

namespace NeighborhoodWatch.DAC.Entity
{
    public partial class Incident
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string County { get; set; }
        public string State { get; set; }
    }
}
