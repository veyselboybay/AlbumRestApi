using AlbumRestApi.Dto;
using AlbumRestApi.Models;
using AlbumRestApi.Repositories;

namespace AlbumRestApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieRepository _movieRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public Task<Genre> Create(NewGenreDto genre)
        {
            var newGenre = new Genre();
            newGenre.Id = Guid.NewGuid();
            newGenre.Name = genre.name;
            return _genreRepository.Add(newGenre);
        }

        public Task Delete(Genre genre)
        {
            return _genreRepository.Delete(genre);
        }

        public Task<IEnumerable<Genre>> FindAll()
        {
            return _genreRepository.FindAll();
        }

        public Task<Genre> FindById(Guid id)
        {
            return _genreRepository.FindById(id);
        }
    }
}
