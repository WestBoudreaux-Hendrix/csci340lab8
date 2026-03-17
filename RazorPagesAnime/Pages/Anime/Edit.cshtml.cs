using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Data;
using RazorPagesAnime.Models;

namespace RazorPagesAnime.Pages_Anime
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public EditModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
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

            var anime =  await _context.Anime.FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }
            Anime = anime;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Anime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(Anime.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AnimeExists(int id)
        {
            return _context.Anime.Any(e => e.Id == id);
        }
    }
}
