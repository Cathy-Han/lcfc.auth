using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Location
{
    /// <summary>
    /// 位置维护服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ILocationManage:IServiceKey
    {
        Task<ILocation> Create(ILocation model);

        Task<ILocation> Update(ILocation model);

        Task<bool> Delete(ILocation model);

        Task<bool> Delete(string code);
    }
}
