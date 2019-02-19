using lcfc.auth.IModules.Location;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class Location : ILocation
    {
        public string Domain { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Deep { get; set; }
        public string Level { get; set; }
        public ILocation Parent { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool Deleted { get; set; }
        public string Language { get; set; }
    }
}
