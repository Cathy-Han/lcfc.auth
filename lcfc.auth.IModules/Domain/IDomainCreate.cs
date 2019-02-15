using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Domain
{
    /// <summary>
    /// 域创建服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IDomainCreate:IServiceKey
    {
        /// <summary>
        /// 创建域
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IDomain> Create(IDomain model);
    }
}
