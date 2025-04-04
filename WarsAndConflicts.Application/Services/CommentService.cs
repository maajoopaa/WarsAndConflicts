using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess;
using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly WarsDbContext _context;

        public CommentService(WarsDbContext context)
        {
            _context = context;
        }

        public async Task<List<CommentEntity>> GetList(Guid warId)
        {
            var commentEntities = await _context.Comments
                .AsNoTracking()
                .Where(c => c.WarId == warId)
                .ToListAsync();

            return commentEntities;
        }

        public async Task<Guid> Create(string body, Guid userId, Guid warId)
        {
            var commentEntity = new CommentEntity
            {
                Body = body,
                CreatedById = userId,
                CreatedAt = DateTime.UtcNow,
                WarId = warId
            };

            await _context.Comments
                    .AddAsync(commentEntity);

            await _context.SaveChangesAsync();

            return commentEntity.Id;
        }
    }
}
