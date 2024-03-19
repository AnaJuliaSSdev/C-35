using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "The movie title is mandatory.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The movie genre is mandatory.")]
        [StringLength(50, ErrorMessage = "The movie genre cannot exceed 50 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "The movie duration is mandatory.")]
        [Range(60, 600, ErrorMessage = "The movie duration must be between 60 and 600 minutes.")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "The movie synopsis is mandatory.")]
        public string Synopsis { get; set; }
    }
}
