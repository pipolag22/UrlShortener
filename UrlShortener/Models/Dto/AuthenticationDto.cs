using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models.Dto
{
    public class AuthenticationDto
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
