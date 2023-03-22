using AlbumRestApi.Dto;
using AlbumRestApi.Models;

namespace AlbumRestApi.Services
{
    public interface IGenreService
    {
        Task<Genre> FindById(Guid id);
        Task<Genre> Create(NewGenreDto genre);
        Task<IEnumerable<Genre>> FindAll();
        Task Delete(Genre genre);
    }
}
