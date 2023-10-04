using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortener.Entities
{
    public class XYZ
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string? Url { get; set; }
        public string? UrlShort { get; set; }

        public int? Id { get; set; }
    }
}
