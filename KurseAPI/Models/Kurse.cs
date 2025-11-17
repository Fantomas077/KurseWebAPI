using System.ComponentModel.DataAnnotations;

namespace KurseAPI.Models
{
    public class Kurse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is pflicht")]
        public string Name { get; set; }
        [Range(0, 20, ErrorMessage = "Score beetween 0 and 20")]
        public int Score { get; set; }
        [MaxLength(50, ErrorMessage = "Max 20 Charakter")]
        [Required]
        public string Description { get; set; }
    }
}
