using System.ComponentModel.DataAnnotations;

namespace AlbumRestApi.Models
{
    public class Genre
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

    }
}
