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
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    SubGenre= "blah",
                    Rating = 7.99M
                },

                new Anime
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    SubGenre= "blah",
                    Rating = 8.99M
                },

                new Anime
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    SubGenre= "blah",
                    Rating = 9.99M
                },

                new Anime
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    SubGenre= "blah",
                    Rating = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}