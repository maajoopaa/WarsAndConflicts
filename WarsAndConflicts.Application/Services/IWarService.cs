using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IWarService
    {
        Task<Guid> Create(string title, string description, byte[] image, Guid periodId);
        Task<WarEntity?> Get(Guid id);
        Task<List<WarEntity>> GetList(Guid periodId);
        Task<Guid> Remove(Guid id);
        Task<Guid> Update(Guid id, string title, string description, byte[] image, Guid periodId);
    }
}