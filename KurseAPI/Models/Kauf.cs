using KurseAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Kauf
{
    [Key]
    public int Id { get; set; }
    public float Price { get; set; }
    public DateTime Datum { get; set; }

    // FK vers User
    public int UserId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }

    // FK to Kurs
    public int KursId { get; set; }
    [ForeignKey("KursId")]
    public Kurse Kurs { get; set; }
}
