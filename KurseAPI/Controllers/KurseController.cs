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
        public IEnumerable<Kurse> Get()
        {
            return KurseListe;
        }
        [HttpGet("{id}")]
        public Kurse Get(int id)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            return pos;
        }

        [HttpPost]
        public void Post([FromBody] Kurse kurse)
        {
            KurseListe.Add(kurse);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos != null)
            {
                KurseListe.Remove(pos);
            }


        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Kurse kurse)
        {
            var pos = KurseListe.Find(x => x.Id == id);
            if (pos != null)
            {
                pos.Name = kurse.Name;
                pos.Score = kurse.Score;
                pos.Description = kurse.Description;

            }


        }

    }
}
