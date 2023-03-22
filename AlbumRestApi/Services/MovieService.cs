using AlbumRestApi.Models;
using AlbumRestApi.Repositories;

namespace AlbumRestApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public Task<Movie> Create(Movie movie)
        {
            movie.Id = Guid.NewGuid();
            return _movieRepository.Add(movie);
        }

        public Task Delete(Movie movie)
        {
            return _movieRepository.Delete(movie);
        }

        public Task<Movie> FindById(Guid id)
        {
            return _movieRepository.FindById(id);
        }

        public Task<Movie> FindByName(string name)
        {
            return _movieRepository.FindByName(name);
        }
    }
}
