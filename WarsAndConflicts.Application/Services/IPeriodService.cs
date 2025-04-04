using WarsAndConflicts.DataAccess.Entities;

namespace WarsAndConflicts.Application.Services
{
    public interface IPeriodService
    {
        Task<PeriodEntity> Create(string title, string description, byte[] image);
        Task<PeriodEntity?> Get(Guid id);
        Task<List<PeriodEntity>> GetList();
        Task<bool> Remove(Guid id);
        Task<PeriodEntity?> Update(Guid id, string title, string description, byte[] image);
    }
}