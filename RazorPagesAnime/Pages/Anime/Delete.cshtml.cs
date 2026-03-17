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
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public DeleteModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Anime Anime { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime.FirstOrDefaultAsync(m => m.Id == id);

            if (anime is not null)
            {
                Anime = anime;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anime = await _context.Anime.FindAsync(id);
            if (anime != null)
            {
                Anime = anime;
                _context.Anime.Remove(Anime);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
