using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IWarService
    {
        Task<WarEntity> Create(string title, string description, byte[] image, Guid periodId);
        Task<WarEntity?> Get(Guid id);
        Task<List<WarEntity>> GetList(Guid periodId);
        Task<bool> Remove(Guid id);
        Task<WarEntity?> Update(Guid id, string title, string description, byte[] image, Guid periodId);
        Task<List<WarEntity>> Search(string query);
    }
}