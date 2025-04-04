using Microsoft.AspNetCore.Http;
using System.Net.Http;
using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IUserService
    {
        Task<UserEntity?> Create(string username, string email, string password);
        Task<UserEntity?> Get(Guid id);
        Task<UserEntity?> Get(string username, string password);
        Task<bool> Authorize(UserEntity user, HttpContext context);
    }
}