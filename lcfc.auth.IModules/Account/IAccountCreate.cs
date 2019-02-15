using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Account
{
    /// <summary>
    /// 账号创建服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAccountCreate:IServiceKey
    {
        Task<IAccount> Create(IAccount model);
    }
}
