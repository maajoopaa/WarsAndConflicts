using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IUserService
    {
        Task<Guid> Create(string username, string email, string password);
        Task<UserEntity?> Get(Guid id);
    }
}