namespace AlbumRestApi.Repositories
{
    public class BaseRepository
    {
        protected readonly ApplicationDBContext _dbContext;
        public BaseRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
