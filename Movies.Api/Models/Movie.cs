namespace Movies.Api.Models;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public int ReleaseYear { get; set; }
}