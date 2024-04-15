using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int Duration { get; set; }
    public string Synopsis { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }
}
