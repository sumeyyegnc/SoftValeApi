using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftValeApi.Models;

namespace SoftValeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : ControllerBase
    {
        private readonly AppDbContext context;

        public AracController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Arac/GetArac
        [HttpGet]
        [Route("GetArac")]
        public async Task<IEnumerable<Arac>> GetArac()
        {
            return await context.Araclar.ToListAsync();
        }

        // POST: api/Arac/AddArac
        [HttpPost]
        [Route("AddArac")]
        public async Task<Arac> AddArac(Arac arac)
        {
            context.Araclar.Add(arac);
            await context.SaveChangesAsync();
            return arac;
        }

        [HttpPut]
        [Route("UpdateArac/{id}")]
        public async Task<IActionResult> UpdateArac(int id, Arac arac)
        {
            var dbArac = await context.Araclar.FindAsync(id);

            if (dbArac == null)
                return NotFound();

            dbArac.Plaka = arac.Plaka;
            dbArac.Marka = arac.Marka;
            dbArac.Renk = arac.Renk;

            await context.SaveChangesAsync();
            return Ok(dbArac);
        }
        // DELETE: api/Arac/DeleteArac/5
        [HttpDelete]
        [Route("DeleteArac/{id}")]
        public async Task<bool> DeleteArac(int id)
        {
            bool durum = false;

            var arac = await context.Araclar.FindAsync(id);

            if (arac != null)
            {
                durum = true;
                context.Araclar.Remove(arac);
                await context.SaveChangesAsync();
            }

            return durum;
        }
    }
}