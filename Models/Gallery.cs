using System.ComponentModel.DataAnnotations;

namespace Learing_Core.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Location { get; set; }
    }
}
