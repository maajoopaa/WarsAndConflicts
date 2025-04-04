using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IPeriodService
    {
        Task<Guid> Create(string title, string description, byte[] image);
        Task<PeriodEntity?> Get(Guid id);
        Task<List<PeriodEntity>> GetList();
        Task<Guid> Remove(Guid id);
        Task<Guid> Update(Guid id, string title, string description, byte[] image, List<WarEntity> wars);
    }
}