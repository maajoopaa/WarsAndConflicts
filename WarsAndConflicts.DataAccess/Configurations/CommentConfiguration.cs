using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess.Entities;
using WarsAndConflicts.Domain.Models;

namespace WarsAndConflicts.DataAccess.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<CommentEntity>
    {
        public void Configure(EntityTypeBuilder<CommentEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.War)
                .WithMany(w => w.Comments)
                .HasForeignKey(c => c.WarId);

            builder.Property(c => c.Body)
                .HasMaxLength(Comment.MAX_BODY_LENGTH);
        }
    }
}
