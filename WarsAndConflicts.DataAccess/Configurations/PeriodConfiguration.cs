using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.DataAccess.Configurations
{
    public class PeriodConfiguration : IEntityTypeConfiguration<PeriodEntity>
    {
        public void Configure(EntityTypeBuilder<PeriodEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Wars)
                .WithOne(w => w.Period)
                .HasForeignKey(w => w.PeriodId);
        }
    }
}
