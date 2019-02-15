using lcfc.auth.IModules.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Location
{
    public interface ILocation:ICreateTime,IUpdateTime,IDeleted, ILanguage
    {
        string Domain { get; set; }

        string Code { get; set; }

        string Name { get; set; }

        int Deep { get; set; }

        string Level { get; set; }

        ILocation Parent { get; set; }

        string Description { get; set; }
    }
}
