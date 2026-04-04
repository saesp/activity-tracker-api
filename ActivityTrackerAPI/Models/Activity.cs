using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ActivityTrackerAPI.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; } //permette di ottenere anche i dati della categoria 
        public DateTime CreatedAt { get; set; }
    }
}


//represents the database entity (table)
//used by Entity Framework to map data to db
//should not be exposed directly in API input