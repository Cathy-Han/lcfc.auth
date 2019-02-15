using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Domain
{
    /// <summary>
    /// 域删除服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IDomainDelete : IServiceKey
    {
        Task<bool> Delete(IDomain model);

        Task<bool> Delete(string domain_id);
    }
}
