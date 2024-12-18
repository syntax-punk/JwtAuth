namespace Movies.Api.Contracts;

public class MovieRequestDto
{
    public string Title { get; init; }
    public int ReleaseYear { get; set; }
}