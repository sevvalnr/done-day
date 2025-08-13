using DoneDay.Core.Entities;
using DoneDay.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoneDay.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitController : ControllerBase
    {
        private readonly IHabitRepository _habitRepository;

        public HabitController(IHabitRepository habitRepository)
        {
            _habitRepository = habitRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var habits = await _habitRepository.GetAllAsync();
            return Ok(habits);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var habit = await _habitRepository.GetByIdAsync(id);
            if (habit == null) return NotFound();
            return Ok(habit);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Habit habit)
        {
            await _habitRepository.AddAsync(habit);
            return CreatedAtAction(nameof(GetById), new { id = habit.Id }, habit);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Habit habit)
        {
            if (id != habit.Id) return BadRequest();
            await _habitRepository.UpdateAsync(habit);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _habitRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
