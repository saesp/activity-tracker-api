using System.ComponentModel.DataAnnotations;


namespace ActivityTrackerAPI.DTOs
{
    public class CreateActivityDto
    {
        public string Title { get; set; }

        [Range(1, 24)]
        public int Duration { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}





//DTO used to receive data from the client (POST request)
//it doesn't include Id or CreatedAt (handled by backend)