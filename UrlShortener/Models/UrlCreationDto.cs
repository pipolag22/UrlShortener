using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class UrlCreationDto
    {
        [Required]
        public int URL { get; set; }

        public int? ID { get; set; }
    }
}
