using System.ComponentModel.DataAnnotations;

namespace AlbumRestApi.Models
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public Genre Genre { get; set; }
    }
}
