using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Account
{
    public interface IAccount:ICreateTime,IUpdateTime,IDeleted,IDomainKey
    {
        long Number { get; set; }

        string Email { get; set; }

        string MobileNum { get; set; }

        string Type { get; set; }

        string TargetKey { get; set; }

        IAccount Parent { get; set; }

        string NickName { get; set; }

        string Status { get; set; }

        bool Enabled { get; set; }

        bool IsSystemed { get; set; }

        Dictionary<long,string> Roles { get; set; }
    }
}
