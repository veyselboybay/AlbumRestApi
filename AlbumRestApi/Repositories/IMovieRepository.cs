using AlbumRestApi.Models;

namespace AlbumRestApi.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> Add(Movie movie);
        Task<Movie> FindById(Guid id);
        Task<Movie> FindByName(string name);
        Task Delete(Movie movie);
    }
}
