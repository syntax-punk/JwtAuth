using Movies.Api.Models;

namespace Movies.Api.Services;

public static class MoviesService
{
    private static readonly List<Movie> Movies =
    [
        new Movie { Id = Guid.NewGuid(), Title = "The Shawshank Redemption", ReleaseYear = 1994 },
        new Movie { Id = Guid.NewGuid(), Title = "The Godfather", ReleaseYear = 1972 },
        new Movie { Id = Guid.NewGuid(), Title = "The Dark Knight", ReleaseYear = 2008 }
    ];
    
    public static List<Movie> GetMovies() => Movies;
    
    public static void AddMovie(Movie movie) => Movies.Add(movie);

    public static Movie GetMovieById(Guid guid)
    {
        var result = Movies.FirstOrDefault(m => m.Id == guid);
        return result;
    }

    public static Movie ConvertToMovie(MovieRequestDto movieDto)
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