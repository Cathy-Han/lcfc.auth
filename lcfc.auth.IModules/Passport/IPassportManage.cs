using lcfc.auth.IModules.Account;
using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Passport
{
    /// <summary>
    /// 通行证管理服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IPassportManage : IServiceKey
    {
        Task<IPassport> Create(IPassport model);

        Task<bool> Delete(IPassport model);
    }
}
