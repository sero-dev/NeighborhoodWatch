using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace NeighborhoodWatch.DAC.Entity
{
    public partial class Incident
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public NpgsqlPoint Location { get; set; }
    }
}
