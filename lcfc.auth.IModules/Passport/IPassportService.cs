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
    /// 通行证服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IPassportService : IServiceKey
    {
        Task<IPassport> Register(IAccount account, IPassport passport);

        Task<bool> BindEmail(Guid id, string email);

        Task<bool> UnBindEmail(Guid id, string email);

        Task<bool> BindMobile(Guid id, string mobile_num);

        Task<bool> UnBindMobile(Guid id, string mobile_num);
    }
}
