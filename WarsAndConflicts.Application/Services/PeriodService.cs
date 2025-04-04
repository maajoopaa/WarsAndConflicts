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
    public class PeriodService : IPeriodService
    {
        private readonly WarsDbContext _context;

        public PeriodService(WarsDbContext context)
        {
            _context = context;
        }

        public async Task<PeriodEntity?> Get(Guid id)
        {
            var periodEntity = await _context.Periods
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);

            return periodEntity;
        }

        public async Task<List<PeriodEntity>> GetList()
        {
            var periodEntities = await _context.Periods
                .AsNoTracking()
                .ToListAsync();

            return periodEntities;
        }

        public async Task<Guid> Create(string title, string description, byte[] image)
        {
            var periodEntity = new PeriodEntity
            {
                Title = title,
                Description = description,
                Image = image
            };

            await _context.Periods
                .AddAsync(periodEntity);

            await _context.SaveChangesAsync();

            return periodEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string description, byte[] image, List<WarEntity> wars)
        {
            var periodEntity = await Get(id);

            if (periodEntity != null)
            {
                periodEntity.Title = title;
                periodEntity.Description = description;
                periodEntity.Image = image;
                periodEntity.Wars = wars;

                _context.Periods
                    .Update(periodEntity);

                await _context.SaveChangesAsync();
            }

            return id;
        }

        public async Task<Guid> Remove(Guid id)
        {
            var periodEntity = await Get(id);

            if (periodEntity != null)
            {
                _context.Periods.Remove(periodEntity);

                await _context.SaveChangesAsync();
            }

            return id;
        }
    }
}
