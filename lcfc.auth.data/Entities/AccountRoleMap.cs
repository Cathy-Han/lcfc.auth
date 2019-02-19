using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.data.Entities
{
    public class AccountRoleMap:ICreateTime,IDomainKey
    {
        public long Account { get; set; }

        public long RoleId { get; set; }

        public bool ByManual { get; set; }

        public bool ByDepend { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime CreateTime { get; set; }
        public TimeSpan TimeStamp { get; set; }
        public string Domain { get; set; }
        public string Location { get; set; }
    }
}
