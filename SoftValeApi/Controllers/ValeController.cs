using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftValeApi.Models;

namespace SoftValeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValeController : ControllerBase
    {
        private readonly AppDbContext context;

        public ValeController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Vale/GetVale
        [HttpGet]
        [Route("GetVale")]
        public async Task<IEnumerable<Vale>> GetVale()
        {
            return await context.Valeler.ToListAsync();
        }

        // POST: api/Vale/AddVale
        [HttpPost]
        [Route("AddVale")]
        public async Task<Vale> AddVale(Vale vale)
        {
            context.Valeler.Add(vale);
            await context.SaveChangesAsync();
            return vale;
        }

        [HttpPut]
        [Route("UpdateVale/{id}")]
        public async Task<IActionResult> UpdateVale(int id, Vale vale)
        {
            var dbVale = await context.Valeler.FindAsync(id);

            if (dbVale == null)
                return NotFound();

            dbVale.AdSoyad = vale.AdSoyad;
            dbVale.Vardiya = vale.Vardiya;

            await context.SaveChangesAsync();
            return Ok(dbVale);
        }

        // DELETE: api/Vale/DeleteVale/5
        [HttpDelete]
        [Route("DeleteVale/{id}")]
        public async Task<bool> DeleteVale(int id)
        {
            bool durum = false;

            var veri = await context.Valeler.FindAsync(id);

            if (veri != null)
            {
                durum = true;
                context.Valeler.Remove(veri);
                await context.SaveChangesAsync();
            }

            return durum;
        }
    }
}