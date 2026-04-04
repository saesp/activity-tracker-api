using System.ComponentModel.DataAnnotations;

namespace ActivityTrackerAPI.DTOs
{
    public class UpdateActivityDto
    {
        public string Title { get; set; }

        [Range(1, 24)]
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}
