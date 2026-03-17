using Microsoft.EntityFrameworkCore;
using RazorPagesAnime.Data;

namespace RazorPagesAnime.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new RazorPagesAnimeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesAnimeContext>>()))
        {
            if (context == null || context.Anime == null)
            {
                throw new ArgumentNullException("Null RazorPagesMovieContext");
            }

            // Look for any movies.
            if (context.Anime.Any())
            {
                return;   // DB has been seeded
            }

            context.Anime.AddRange(
                new Anime
                {
                    Title = "A Little Snow Fairy Sugar",
                    ReleaseDate = DateTime.Parse("2001-10-2"),
                    Genre = "Comedy",
                    SubGenre= "Slice-of-life",
                    Rating = 7.1M
                },

                new Anime
                {
                    Title = "Code Geass",
                    ReleaseDate = DateTime.Parse("2006-10-6"),
                    Genre = "Action-Drama",
                    SubGenre= "Sci-fi",
                    Rating = 8.7M
                },

                new Anime
                {
                    Title = "Ginban Kaleidoscope",
                    ReleaseDate = DateTime.Parse("2005-10-08"),
                    Genre = "Romantic Comedy",
                    SubGenre= "Sport",
                    Rating = 7.2M
                },

                new Anime
                {
                    Title = "Kono Minikuku",
                    ReleaseDate = DateTime.Parse("2004-4-1"),
                    Genre = "Action",
                    SubGenre= "Sci-fi",
                    Rating = 6.1M
                }
            );
            context.SaveChanges();
        }
    }
}