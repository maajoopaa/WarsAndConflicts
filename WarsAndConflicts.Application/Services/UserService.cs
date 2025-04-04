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
    public class UserService : IUserService
    {
        private readonly WarsDbContext _context;

        public UserService(WarsDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> Get(Guid id)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == id);

            return userEntity;
        }

        public async Task<Guid> Create(string username, string email, string password)
        {
            try
            {
                var userEntity = new UserEntity
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                await _context.Users
                    .AddAsync(userEntity);

                await _context.SaveChangesAsync();

                return userEntity.Id;
            }
            catch
            {
                return Guid.Empty;
            }
        }
    }
}
