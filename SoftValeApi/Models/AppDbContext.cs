using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SoftValeApi.Models
{
    public class AppDbContext:DbContext
    {
        
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Musteri> Musteriler { get; set; }
            public DbSet<Arac> Araclar { get; set; }
            public DbSet<Vale> Valeler { get; set; }
            public DbSet<ParkYeri> Otoparklar { get; set; }
        }
    }

