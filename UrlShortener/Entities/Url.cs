using static UrlShortener.Entities.Category;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UrlShortener.Entities
{
    public class Url
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UrlShort { get; set; }

        public string? UrlLong { get; set; }

        public int contador { get; set; } = 1;

        [ForeignKey("IdCategoria")]
        public int IdCategoria { get; set; }
        public Category Categoria { get; set; }

        [ForeignKey("IdUser")]

        public int IdUser { get; set; }

        public User? User { get; set; }

    }
}
