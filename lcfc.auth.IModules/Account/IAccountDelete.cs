using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Account
{
    /// <summary>
    /// 账号删除服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAccountDelete : IServiceKey
    {
        Task<bool> Delete(IAccount model);
        Task<bool> Delete(long account_num);
    }
}
