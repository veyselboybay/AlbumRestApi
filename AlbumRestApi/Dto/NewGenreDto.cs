using System.ComponentModel.DataAnnotations;

namespace AlbumRestApi.Dto
{
    public class NewGenreDto
    {
        [Required]
        public string name { get; set; }
    }
}
