using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Domain
{
    /// <summary>
    /// 域查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IDomainView : IServiceKey
    {
        Task<IDomain> Get(string domain_id);

        Task<IDomain[]> Get();
    }
}
