using KurseAPI.Models;
using KurseAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KurseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KurseV2Controller : ControllerBase
    {
        private readonly KurseDbContext _dbContext;

        public KurseV2Controller(KurseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kurse>>> GetAllKurse()
        {

            var kurse = await _dbContext.Kurses
                .Include(k => k.Language)
                .ToListAsync();
            return kurse;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Kurse>> GetKurseById(int id)
        {
            var kurs = await _dbContext.Kurses
                .FirstOrDefaultAsync(o => o.Id == id);

            if (kurs == null)
                return NotFound($"Kurs with Id={id} not found");

            return kurs;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] Kurse kurse)
        {

            var exist = await _dbContext.Kurses
                .FirstOrDefaultAsync(o => o.Name == kurse.Name);
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

            kurse.Id = 0;

            _dbContext.Kurses.Add(kurse);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetKurseById), new { id = kurse.Id }, kurse);
        }


    }
}
