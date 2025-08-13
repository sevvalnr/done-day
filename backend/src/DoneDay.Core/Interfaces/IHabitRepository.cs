using DoneDay.Core.Entities;

namespace DoneDay.Core.Interfaces
{
    public interface IHabitRepository
    {
        Task<List<Habit>> GetAllAsync();
        Task<Habit?> GetByIdAsync(int id);
        Task AddAsync(Habit habit);
        Task UpdateAsync(Habit habit);
        Task DeleteAsync(int id);
    }
}
