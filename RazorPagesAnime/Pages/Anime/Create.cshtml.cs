using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesAnime.Data;
using RazorPagesAnime.Models;

namespace RazorPagesAnime.Pages_Anime
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public CreateModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Anime Anime { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Anime.Add(Anime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
