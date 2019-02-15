using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Role
{
    public interface IRole:IPrimaryKey,ICreateTime,IUpdateTime,IDomainKey,IDeleted,ILanguage
    {
        string Name { get; set; }

        string Label { get; set; }

        string Description { get; set; }

        string[] Modules { get; set; }
    }
}
