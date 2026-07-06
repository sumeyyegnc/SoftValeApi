using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftValeApi.Models;

namespace SoftValeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkYeriController : ControllerBase
    {
        private readonly AppDbContext context;

        public ParkYeriController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("GetParkYeri")]
        public async Task<IEnumerable<ParkYeri>> GetParkYeri()
        {
            return await context.Otoparklar.ToListAsync();
        }

        [HttpPost]
        [Route("AddParkYeri")]
        public async Task<ParkYeri> AddParkYeri(ParkYeri parkYeri)
        {
            context.Otoparklar.Add(parkYeri);
            await context.SaveChangesAsync();

            return parkYeri;
        }

        [HttpPut]
        [Route("UpdateParkYeri/{id}")]
        public async Task<IActionResult> UpdateParkYeri(int id, ParkYeri parkYeri)
        {
            var dbPark = await context.Otoparklar.FindAsync(id);

            if (dbPark == null)
                return NotFound("Park yeri bulunamadı");

            dbPark.OtoparkAdi = parkYeri.OtoparkAdi;
            dbPark.Kapasite = parkYeri.Kapasite;

            await context.SaveChangesAsync();

            return Ok(dbPark);
        }

        [HttpDelete]
        [Route("DeleteParkYeri/{id}")]
        public async Task<bool> DeleteParkYeri(int id)
        {
            bool durum = false;

            var parkYeri = await context.Otoparklar.FindAsync(id);

            if (parkYeri != null)
            {
                durum = true;
                context.Otoparklar.Remove(parkYeri);
                await context.SaveChangesAsync();
            }

            return durum;
        }
    }
}