using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Role
{
    /// <summary>
    /// 角色维护服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IRoleManage:IServiceKey
    {
        Task<IRole> Create(IRole model);

        Task<IRole> Update(IRole model);

        Task<bool> Delete(IRole model);

        Task<bool> Delete(long id);
    }
}
