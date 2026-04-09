using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivityTrackerAPI.Data;
using ActivityTrackerAPI.Models;
using ActivityTrackerAPI.DTOs;

namespace ActivityTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/categories")] 
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }


        //GET - VIEW LIST
        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            var categories = await _context.Categories.ToListAsync();
            return Ok(categories); 
        }

        //POST - CREATE
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return Ok(category);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var existing = await _context.Categories.FindAsync(id);

            if (existing == null) { return NotFound(); }

            _context.Categories.Remove(existing);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


