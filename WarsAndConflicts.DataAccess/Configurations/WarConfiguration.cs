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
    public class WarConfiguration : IEntityTypeConfiguration<WarEntity>
    {
        public void Configure(EntityTypeBuilder<WarEntity> builder)
        {
            builder.HasKey(w => w.Id);
        }
    }
}
