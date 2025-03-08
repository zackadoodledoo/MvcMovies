using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using MvcMovies.Models;
using MvcMovies.Data;
using MvcMovie.Models;

namespace MvcMovies.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvcMoviesContext(
            serviceProvider.GetRequiredService<DbContextOptions<MvcMoviesContext>>());

        // Look for any movies.
        if (context.Movie.Any())
        {
            return;   // DB has been seeded
        }
        context.Movie.AddRange(
            new Movie
            {
                Title = "The RM",
                ReleaseDate = DateTime.Parse("2003-1-31"),
                Genre = "Comedy",
                ImageName = "the_rm",
            },
            new Movie
            {
                Title = "The Other Side of Heaven",
                ReleaseDate = DateTime.Parse("2001-12-14"),
                Genre = "Drama",
                ImageName = "the_other_side_of_heaven",
            },
            new Movie
            {
                Title = "Meet the Mormons",
                ReleaseDate = DateTime.Parse("2014-10-10"),
                Genre = "Documentary",
                ImageName = "meet_the_mormons",
            }
        );
        context.SaveChanges();
    }
}
