using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.DataAccess
{
    public class WarsDbContext : DbContext
    {
        public WarsDbContext(DbContextOptions<WarsDbContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<PeriodEntity> Periods { get; set; }

        public DbSet<WarEntity> Wars { get; set; }
    }
}
