using System.ComponentModel.DataAnnotations;

namespace KurseAPI.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Designation { get; set; }
        public List<Kurse> Kurse { get; set; }
    }
}
