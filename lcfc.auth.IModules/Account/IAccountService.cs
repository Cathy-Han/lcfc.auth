using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace lcfc.auth.IModules.Account
{
    /// <summary>
    /// 账号查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAccountService : IServiceKey
    {
        IAccount Get(long account_num);

        IAccount Get(string identity_key);
    }
}
