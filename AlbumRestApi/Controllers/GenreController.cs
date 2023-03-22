using AlbumRestApi.Dto;
using AlbumRestApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace AlbumRestApi.Controllers
{
    [Route("genre")]
    public class GenreController : BaseController<GenreController>
    {
        private readonly IGenreService _genreService;
        public GenreController(ILogger<GenreController> logger, IGenreService genreService) : base(logger)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NewGenreDto newGenreDto)
        {
            try
            {
                return Ok(await _genreService.Create(newGenreDto));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var genre = await _genreService.FindById(id);
            if(genre == null)
            {
                return NotFound();
            }
            var movieList = new MovieListDto();
            movieList.movies = genre.Movies;

            return Ok(movieList);
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            return Ok(await _genreService.FindAll());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            var genre = await _genreService.FindById(id);

            if(genre == null)
            {
                return NotFound("Genre Not Found");
            }
            try
            {
                await _genreService.Delete(genre);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return NoContent();
        }

    }
}
