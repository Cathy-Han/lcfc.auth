using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Common
{
    public interface ICreateTime
    {
        DateTime CreateTime { get; set; }

        TimeSpan TimeStamp { get; set; }
    }
}
