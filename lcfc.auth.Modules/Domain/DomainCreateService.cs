using lcfc.auth.IModules.Domain;
using lcfc.auth.Modules.Repositories;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.Modules.Domain
{
    public class DomainCreateService : ProxyServiceBase,IDomainCreate
    {
        private readonly DomainRepository _domainRepository;

        public DomainCreateService(DomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }

        public async Task<IDomain> Create(IDomain model)
        {
            try
            {
                int res = await _domainRepository.Create(model);
                if (res > 0)
                {
                    return await _domainRepository.Get(model.Id);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
