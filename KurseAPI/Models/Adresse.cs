using System.ComponentModel.DataAnnotations.Schema;

namespace KurseAPI.Models
{
    public class Adresse
    {
        public int Id { get; set; }

        public string Stadt { get; set; }
        public string PLZ { get; set; }
        public string Strasse { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
