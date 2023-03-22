using System.ComponentModel.DataAnnotations;

namespace AlbumRestApi.Dto
{
    public class NewMovieDto
    {
        [Required]
        public Guid movieId { get; set; }
        [Required]
        public string name { get; set; }
    }
}
