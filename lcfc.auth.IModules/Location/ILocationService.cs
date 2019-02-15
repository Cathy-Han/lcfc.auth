using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Location
{
    /// <summary>
    /// 位置查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ILocationService:IServiceKey
    {
        Task<ILocation> Get(string code);

        Task<ILocation[]> GetChildren(string code);

        Task<ILocation[]> Get();
    }
}
