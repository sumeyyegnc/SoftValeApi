using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftValeApi.Models;

namespace SoftValeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusteriController : ControllerBase
    {
        private readonly AppDbContext context;

        public MusteriController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetMusteri")]
        public async Task<IEnumerable<Musteri>> GetMusteri()
        {
            return await context.Musteriler.ToListAsync();
        }

        [HttpPost]
        [Route("AddMusteri")]
        public async Task<Musteri> AddMusteri(Musteri musteri)
        {
            context.Musteriler.Add(musteri);
            await context.SaveChangesAsync();
            return musteri;
        }

        [HttpPut]
        [Route("UpdateMusteri/{id}")]
        public async Task<IActionResult> UpdateMusteri(int id, Musteri musteri)
        {
            var dbMusteri = await context.Musteriler.FindAsync(id);

            if (dbMusteri == null)
                return NotFound();

            dbMusteri.AdSoyad = musteri.AdSoyad;
            dbMusteri.Telefon = musteri.Telefon;

            await context.SaveChangesAsync();
            return Ok(dbMusteri);
        }

        [HttpDelete]
        [Route("DeleteMusteri/{id}")]
        public async Task<bool> DeleteMusteri(int id)
        {
            bool durum = false;

            var musteri = await context.Musteriler.FindAsync(id);

            if (musteri != null)
            {
                durum = true;
                context.Musteriler.Remove(musteri);
                await context.SaveChangesAsync();
            }

            return durum;
        }
    }
}