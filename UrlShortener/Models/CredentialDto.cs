using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Models
{
    public class CredentialDto
    {
        [Required]

        public string Name { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
