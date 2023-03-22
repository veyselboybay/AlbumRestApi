using AlbumRestApi.Models;
using AlbumRestApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbumRestApi.Controllers
{
    [Route("genres/{genreId}/movies")]
    public class MovieController : BaseController<MovieController>
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly IFileUploadService _fileUploadService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public MovieController(ILogger<MovieController> logger, IGenreService genreService, IFileUploadService fileUploadService, IWebHostEnvironment webHostEnvironment) : base(logger)
        {
            _genreService = genreService;
            _fileUploadService = fileUploadService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] string name, Guid genreId, [FromForm] IFormFile image)
        {
            var genre = await _genreService.FindById(genreId);
            if(genre == null)
            {
                return NotFound();
            }

            var newMovie = new Movie();
            newMovie.Name = name;

            if(image == null || image.Length == 0) 
            {
                return BadRequest("File is empty");            
            }

            // web root path
            string webRoot = _webHostEnvironment.WebRootPath;

            // get extension of the uploaded file
            string extension = Path.GetExtension(webRoot);

            // generate a file name, using GUID to avoid duplicates
            string filename = Path.Combine(webRoot+Guid.NewGuid().ToString(), extension);

            try
            {
                //upload the file
                string uploadFileUrl = await _fileUploadService.UploadFile(image, filename);
                // assign the new file url to the db model
                newMovie.Url= uploadFileUrl;
                newMovie.Genre= genre;
                // save the details in db
                newMovie = await _movieService.Create(newMovie);
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }

            return Ok(newMovie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(Guid id, Guid genreId)
        {
            var movie = await _movieService.FindById(id);
            if(movie == null)
            {
                return NotFound();
            }

            try
            {
                await _movieService.Delete(movie);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }

            return NoContent(); 
        }
    }
}
