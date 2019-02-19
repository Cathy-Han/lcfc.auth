using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class RoleModuleMap : ICreateTime, IDomainKey
    {
        public long RoleId { get; set; }
        public string Package { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
    }
}
