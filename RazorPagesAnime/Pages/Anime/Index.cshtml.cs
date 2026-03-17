using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Data;
using RazorPagesAnime.Models;

namespace RazorPagesAnime.Pages_Anime
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public IndexModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
        {
            _context = context;
        }

        public IList<Anime> Anime { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Anime = await _context.Anime.ToListAsync();
        }
    }
}
