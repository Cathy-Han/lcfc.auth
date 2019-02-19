using lcfc.auth.IModules.Domain;
using lcfc.auth.Modules.Repositories;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.Modules.Domain
{
    public class DomainDeleteService : ProxyServiceBase, IDomainDelete
    {
        private readonly DomainRepository _domainRepository;

        public DomainDeleteService(DomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task<bool> Delete(IDomain model)
        {
            try
            {
                int res = await _domainRepository.Delete(model);
                if (res > 0)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(string domain_id)
        {
            try
            {
                var entity = await _domainRepository.Get(domain_id);
                return await this.Delete(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
