using KurseAPI.Models;
using KurseAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace KurseAPI.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json", "application/xml", Type = typeof(List<string>))]
    [ApiController]
    public class KurseController : ControllerBase
    {
        private static List<Kurse> KurseListe = new List<Kurse>()
        {
             new Kurse(){Id=1,Name="Französisch für Anfänger",Description="Französisch lernen A1-A2",Score=15},
            new Kurse(){Id=2,Name="Python ",Description="Python Kurse",Score=15},
             new Kurse(){Id=3,Name="Mathe für Anfänger",Description="Mathe lernen ",Score=10},
            new Kurse(){Id=4,Name="Data Science für Anfänger",Description="Data Science lernen ",Score=11}
        };

        [HttpGet]
        public IActionResult Get()
        {
            if (KurseListe.Count == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Keine Kurse vorhanden");

            }
            return Ok(KurseListe);
        }



        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos == null)
            {
                return NotFound("keine gefunden");


            }
            return Ok(pos);
        }

        [HttpPost]
        public IActionResult Post([FromForm] Kurse kurse)
        {
            var exist = KurseListe.Find(x => x.Id == kurse.Id);
            if (exist != null)
            {
                return BadRequest("Dieser Kurs existiert bereits.");
            }

            if (kurse.Image != null)
            {
                if (!UploadFiles.TestImage(kurse.Image))
                {
                    return BadRequest("Nur Bilddateien erlaubt (.jpg, .png, .gif).");
                }

                kurse.ImageUrl = UploadFiles.WriteFiles(kurse.Image);
            }






            KurseListe.Add(kurse);


            return CreatedAtAction(nameof(Get), new { id = kurse.Id }, kurse);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] Kurse kurse)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos != null)
            {
                pos.Name = kurse.Name;
                pos.Score = kurse.Score;
                pos.Description = kurse.Description;
                if (kurse.Image != null)
                {
                    if (!UploadFiles.TestImage(kurse.Image))
                        return BadRequest("Nur Bilddateien erlaubt (.jpg, .png, .gif).");

                    pos.ImageUrl = UploadFiles.WriteFiles(kurse.Image);
                }
                return Ok("Der Kurse Wurde erfolgreich updated");

            }
            return NotFound("Kurs wurde nicht gefunden");

        }

    }
}
