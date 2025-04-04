using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text;
using System.Threading.Tasks;
using WarsAndConflicts.DataAccess;
using WarsAndConflicts.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

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

        public async Task<UserEntity?> Get(string username, string password)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

            return userEntity;
        }

        public async Task<UserEntity?> Create(string username, string email, string password)
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

                return userEntity;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Authorize(UserEntity user, HttpContext context)
        {
            try
            {
                var claims = new List<Claim> {
                    new(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await context.SignInAsync(claimsPrincipal);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
