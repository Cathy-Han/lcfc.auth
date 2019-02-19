using lcfc.auth.data;
using lcfc.auth.IModules.Domain;
using Microsoft.EntityFrameworkCore;
using Surging.Core.CPlatform.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lcfc.auth.Modules.Repositories
{
    public class DomainRepository:BaseRepository
    {
        public async Task<int> Create(IDomain entity)
        {
            using (var context = new MyDbContext())
            {
                context.Domain.Add(entity as data.Domain);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(IDomain entity)
        {
            entity.Deleted = true;
            using (var context = new MyDbContext())
            {
                context.Domain.Attach(entity as data.Domain);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<IDomain> Get(string domain_id)
        {
            using (var context = new MyDbContext())
            {
                return await context.Domain.FindAsync(domain_id);
            }
        }

        public IDomain[] Get()
        {
            using (var context = new MyDbContext())
            {
                return context.Domain.AsNoTracking().ToArray();
            }
        }
    }
}
