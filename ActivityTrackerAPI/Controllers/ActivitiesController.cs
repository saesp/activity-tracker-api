using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivityTrackerAPI.Data;
using ActivityTrackerAPI.Models;


namespace ActivityTrackerAPI.Controllers
{
    [ApiController] //this class is a controller API
    [Route("api/activities")] //endpoint
    public class ActivitiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ActivitiesController(AppDbContext context)
        {
            _context = context;
        }


        //GET - VIEW LIST
        [HttpGet] 
        public async Task<IActionResult> GetActivities()
        {
            var activities = await _context.Activities
                .Include(a => a.Category) //include categoria
                .ToListAsync();

            return Ok(activities); //restituisce risposta HTTP 200
        }


        //GET - VIEW ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivity(int id)
        {
            var activity = await _context.Activities
            .Include(a => a.Category)
            .FirstOrDefaultAsync(a => a.Id == id); //a => a.Id == id lambda expression usata per filtrare i dati, equivalente a WHERE in SQL

            if (activity == null) { return NotFound(); }

            return Ok(activity);
        }


        //POST - CREATE
        [HttpPost]
        public async Task<IActionResult> CreateActivity(Activity activity) //Activity activity riceve dati dal frontend
        {
            _context.Activities.Add(activity); //.Add() aggiunge in memoria

            await _context.SaveChangesAsync(); //SaveChangesAsync() salva nel DB
            return CreatedAtAction(nameof(GetActivities), new { id = activity.Id }, activity);
        }


        //PUT - UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, Activity activity)
        {
            var existing = await _context.Activities.FindAsync(id); //Recupero l’entità

            if (existing == null) { return NotFound(); } //per evitare crash

            existing.Title = activity.Title;
            existing.Duration = activity.Duration;
            existing.Date = activity.Date;
            existing.CategoryId = activity.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent(); //204
        }


        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            var existing = await _context.Activities.FindAsync(id);

            if (existing == null) { return NotFound(); }

            _context.Activities.Remove(existing);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


