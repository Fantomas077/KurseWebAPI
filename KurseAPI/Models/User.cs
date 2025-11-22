using System.ComponentModel.DataAnnotations;

namespace KurseAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public Adresse Adresse { get; set; }



        public List<Kauf> Käufe { get; set; }

    }
}
