using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess.Entities;
using WarsAndConflicts.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace WarsAndConflicts.Application.Services
{
    public class WarService : IWarService
    {
        private readonly WarsDbContext _context;

        public WarService(WarsDbContext context)
        {
            _context = context;
        }

        public async Task<WarEntity?> Get(Guid id)
        {
            var warEntity = await _context.Wars
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.Id == id);

            return warEntity;
        }

        public async Task<List<WarEntity>> GetList(Guid periodId)
        {
            var warEntities = await _context.Wars
                .AsNoTracking()
                .Where(w => w.PeriodId == periodId)
                .ToListAsync();

            return warEntities;
        }

        public async Task<WarEntity> Create(string title, string description, byte[] image, Guid periodId)
        {
            var warEntity = new WarEntity
            {
                Title = title,
                Description = description,
                Image = image,
                PeriodId = periodId
            };

            await _context.Wars
                .AddAsync(warEntity);

            await _context.SaveChangesAsync();

            return warEntity;
        }

        public async Task<WarEntity?> Update(Guid id, string title, string description, byte[] image, Guid periodId)
        {
            var warEntity = await Get(id);

            if (warEntity != null)
            {
                warEntity.Title = title;
                warEntity.Description = description;
                warEntity.Image = image;
                warEntity.PeriodId = periodId;

                _context.Wars
                    .Update(warEntity);

                await _context.SaveChangesAsync();
            }

            return warEntity;
        }

        public async Task<bool> Remove(Guid id)
        {
            try
            {
                var warEntity = await Get(id);

                if (warEntity != null)
                {
                    _context.Wars.Remove(warEntity);

                    await _context.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<WarEntity>> Search(string query)
        {
            var warEntities = await _context.Wars
                .AsNoTracking()
                .Where(w => w.Title.ToLower().Contains(query.ToLower()))
                .ToListAsync();

            return warEntities;
        }
    }
}
