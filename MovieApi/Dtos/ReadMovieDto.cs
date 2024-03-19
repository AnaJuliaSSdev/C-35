using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos;

public class ReadMovieDto
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string Synopsis { get; set; }
    public DateTime ConsultTime { get; set; } = DateTime.Now;
}
