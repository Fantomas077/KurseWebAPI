using KurseAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KurseAPI.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult Post([FromBody] Kurse kurse)
        {
            var exist = KurseListe.Find(x => x.Id == kurse.Id);
            if (exist != null)
            {
                return BadRequest("diese kurse existiert schon");
            }
            KurseListe.Add(kurse);
            return Created($"/api/kurse/{kurse.Id}", kurse);


        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos != null)
            {
                KurseListe.Remove(pos);
                return Ok($"{pos.Name} wurde erfolgreich gelöscht");
            }
            return NotFound("wurde nicht gefunden");


        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kurse kurse)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos != null)
            {
                pos.Name = kurse.Name;
                pos.Score = kurse.Score;
                pos.Description = kurse.Description;
                return Ok("Der Kurse Wurde erfolgreich updated");

            }
            return NotFound("wurde nicht gefunden");

        }

    }
}
