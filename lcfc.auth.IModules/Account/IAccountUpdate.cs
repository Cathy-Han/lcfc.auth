using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Account
{
    /// <summary>
    /// 账号更新服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IAccountUpdate : IServiceKey
    {
        Task<IAccount> Update(IAccount model);

        Task<bool> Enabled(long account_num);

        Task<bool> Disabled(long account_num);

        Task<bool> BatchEnabled(long[] nums);

        Task<bool> BatchDisabled(long[] nums);
    }
}
