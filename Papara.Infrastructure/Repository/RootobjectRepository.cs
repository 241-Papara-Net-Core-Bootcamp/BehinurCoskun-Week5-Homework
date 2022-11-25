using Infrastructure.Data;
using Infrastructure.Repository;
using Papara.Core.Entity;
using Papara.Core.Enums;
using Papara.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Papara.Infrastructure.Repository
{
    public class RootobjectRepository : GenericRepository<FakeData>, IFakeDataRepository
    {
        public RootobjectRepository(ApplicationDbContext dbContext, Func<CacheTech, ICacheService> cacheService) : base(dbContext, cacheService)
        {

        }
    }
}
