using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Models;

namespace RazorPagesAnime.Data
{
    public class RazorPagesAnimeContext : DbContext
    {
        public RazorPagesAnimeContext (DbContextOptions<RazorPagesAnimeContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesAnime.Models.Anime> Anime { get; set; } = default!;
    }
}
