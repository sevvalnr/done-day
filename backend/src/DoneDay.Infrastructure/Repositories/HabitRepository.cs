using DoneDay.Core.Entities;
using DoneDay.Core.Interfaces;
using DoneDay.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DoneDay.Infrastructure.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly DoneDayDbContext _context;

        public HabitRepository(DoneDayDbContext context)
        {
            _context = context;
        }

        public async Task<List<Habit>> GetAllAsync()
        {
            return await _context.Habits.ToListAsync();
        }

        public async Task<Habit?> GetByIdAsync(int id)
        {
            return await _context.Habits.FindAsync(id);
        }

        public async Task AddAsync(Habit habit)
        {
            _context.Habits.Add(habit);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Habit habit)
        {
            _context.Habits.Update(habit);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var habit = await _context.Habits.FindAsync(id);
            if (habit != null)
            {
                _context.Habits.Remove(habit);
                await _context.SaveChangesAsync();
            }
        }
    }
}
