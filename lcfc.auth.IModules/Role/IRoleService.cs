using Surging.Core.CPlatform.Ioc;
using Surging.Core.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.IModules.Role
{
    /// <summary>
    /// 角色查询服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface IRoleService:IServiceKey
    {
        Task<IRole> Get(long id);

        Task<IRole[]> GetAccountRoles(long account_num);

        Task<IList<IRole>> Query(string keyword, string label, int page, int size, out int totals);
    }
}
