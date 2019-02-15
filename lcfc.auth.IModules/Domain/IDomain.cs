using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Domain
{
    /// <summary>
    /// 域
    /// </summary>
    public interface IDomain:ICreateTime,IDeleted
    {
        string Id { get; set; }

        string Name { get; set; }

        string Description { get; set; }
    }
}
