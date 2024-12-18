namespace Movies.Api.Contracts;

public class Movie
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public int ReleaseYear { get; set; }
}