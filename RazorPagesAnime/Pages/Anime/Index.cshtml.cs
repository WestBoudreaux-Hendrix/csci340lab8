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
    public class IndexModel : PageModel
    {
        private readonly RazorPagesAnime.Data.RazorPagesAnimeContext _context;

        public IndexModel(RazorPagesAnime.Data.RazorPagesAnimeContext context)
        {
            _context = context;
        }

        public IList<Anime> Anime { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Genre { get; set; }

       public async Task OnGetAsync()
{
    // <snippet_search_linqQuery>
    IQueryable<string> genreQuery = from m in _context.Anime
                                    orderby m.Genre
                                    select m.Genre;
    // </snippet_search_linqQuery>

    var anime = from a in _context.Anime
                 select a;

    if (!string.IsNullOrEmpty(SearchString))
    {
        anime = anime.Where(s => s.Title.Contains(SearchString));
    }

    if (!string.IsNullOrEmpty(Genre))
    {
        anime = anime.Where(x => x.Genre == Genre);
    }

    // <snippet_search_selectList>
    Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
    // </snippet_search_selectList>
    Anime = await anime.ToListAsync();
}
    }
}
