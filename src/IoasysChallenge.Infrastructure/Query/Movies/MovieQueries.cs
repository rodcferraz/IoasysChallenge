using IoasysChallenge.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoasysChallenge.Infrastructure.Query.Movies
{
    public static class MovieQueries
    {
        public static IQueryable<Movie> WithDirector(this IQueryable<Movie> movies, string director)
        {
            if (string.IsNullOrEmpty(director))
                return movies;

            return movies.Where(m => m.Director.Contains(director));
        }

        public static IQueryable<Movie> WithTitle(this IQueryable<Movie> movies, string title)
        {
            if (string.IsNullOrEmpty(title))
                return movies;

            return movies.Where(m => m.Title.Contains(title));
        }

        public static IQueryable<Movie> WithGenre(this IQueryable<Movie> movies, string genre)
        {
            if (string.IsNullOrEmpty(genre))
                return movies;

            return movies.Where(m => m.Genre.Equals(genre));
        }

        public static IQueryable<Movie> WithActors(this IQueryable<Movie> movies, string actors)
        {
            if (string.IsNullOrEmpty(actors))
                return movies;

            return movies.Where(m => m.Actors.Contains(actors));
        }
    }
}
