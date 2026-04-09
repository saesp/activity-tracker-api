using System.ComponentModel.DataAnnotations;


namespace ActivityTrackerAPI.DTOs
{
    public class CreateActivityDto
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [Range(1, 24)]
        public int Duration { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}




//validazione dati per validare prima di arrivare al DB e dare errori chiari al client

//DTO used to receive data from the client (POST request)
//it doesn't include Id or CreatedAt (handled by backend)