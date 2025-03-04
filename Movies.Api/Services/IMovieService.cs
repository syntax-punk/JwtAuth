using Movies.Api.Contracts;

namespace Movies.Api.Services;

public interface IMovieService
{
    List<Movie> GetMovies();
    void AddMovie(Movie movie);
    bool DeleteMovie(Guid guid);
    Movie GetMovieById(Guid guid);
    Movie ConvertToMovie(MovieRequestDto movieDto);
}