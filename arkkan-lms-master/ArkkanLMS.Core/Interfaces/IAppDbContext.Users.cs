using ArkkanLMS.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArkkanLMS.Core.Interfaces
{
    public partial interface IAppDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}

