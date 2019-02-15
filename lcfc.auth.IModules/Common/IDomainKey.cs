using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Common
{
    public interface IDomainKey
    {
        string Domain { get; set; }

        string Location { get; set; }
    }
}
