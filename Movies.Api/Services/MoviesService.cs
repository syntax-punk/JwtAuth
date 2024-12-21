using Movies.Api.Contracts;

namespace Movies.Api.Services;

public class MoviesService : IMovieService
{
    private static readonly List<Movie> Movies =
    [
        new() { Id = Guid.NewGuid(), Title = "The Shawshank Redemption", ReleaseYear = 1994 },
        new() { Id = Guid.NewGuid(), Title = "The Godfather", ReleaseYear = 1972 },
        new() { Id = Guid.NewGuid(), Title = "The Dark Knight", ReleaseYear = 2008 }
    ];

    public List<Movie> GetMovies()
    {
        return Movies;
    }

    public void AddMovie(Movie movie)
    {
        Movies.Add(movie);
    }

    public bool DeleteMovie(Guid guid)
    {
        var movie = Movies.Find(m => m.Id == guid);
        if (movie == null)
            return false;
        
        Movies.Remove(movie);
        return true;
    }

    public Movie GetMovieById(Guid guid)
    {
        var result = Movies.FirstOrDefault(m => m.Id == guid);
        return result;
    }

    public Movie ConvertToMovie(MovieRequestDto movieDto)
    {
        var result = new Movie
        {
            Id = Guid.NewGuid(),
            Title = movieDto.Title,
            ReleaseYear = movieDto.ReleaseYear
        };
        return result;
    }
}