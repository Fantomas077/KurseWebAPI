using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KurseAPI.Models
{
    public class Kurse
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is pflicht")]
        public string Name { get; set; }
        [Range(0, 20, ErrorMessage = "Score beetween 0 and 20")]
        public int Score { get; set; }
        [MaxLength(50, ErrorMessage = "Max 20 Charakter")]
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImageUrl { get; set; }

        [Required]
        public float Price { get; set; }

        public List<Kauf>? Käufe { get; set; }

        public List<Language>? Language { get; set; }

    }




}
