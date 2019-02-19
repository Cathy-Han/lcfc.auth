using lcfc.auth.IModules.Domain;
using System;
using lcfc.auth.IModules.Common;

namespace lcfc.auth.data
{
    public class Domain : IDomain
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public bool Deleted { get; set; }
    }
}
