using AlbumRestApi.Models;

namespace AlbumRestApi.Repositories
{
    public interface IGenreRepository
    {
        Task<Genre> Add(Genre genre);
        Task<Genre> FindById(Guid id);
        Task<IEnumerable<Genre>> FindAll();
        Task Delete(Genre genre);
    }
}
