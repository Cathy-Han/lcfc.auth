using lcfc.auth.IModules.Domain;
using lcfc.auth.Modules.Repositories;
using Surging.Core.ProxyGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.Modules.Domain
{
    public class DomainViewService : ProxyServiceBase, IDomainView
    {
        private readonly DomainRepository _domainRepository;

        public DomainViewService(DomainRepository domainRepository)
        {
            _domainRepository = domainRepository;
        }
        public Task<IDomain> Get(string domain_id)
        {
            return _domainRepository.Get(domain_id);
        }

        public Task<IDomain[]> Get()
        {
            return Task.Run(()=> {
                return _domainRepository.Get();
            });
        }
    }
}
