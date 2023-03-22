using AlbumRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbumRestApi.Repositories
{
    public class MovieRepository : BaseRepository, IMovieRepository
    {
        public MovieRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<Movie> Add(Movie movie)
        {
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task Delete(Movie movie)
        {
            _dbContext.Remove(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Movie> FindById(Guid id)
        {
            return await _dbContext.Movies.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Movie> FindByName(string name)
        {
            return await _dbContext.Movies.Where(m => m.Name == name).FirstOrDefaultAsync();
        }
    }
}
