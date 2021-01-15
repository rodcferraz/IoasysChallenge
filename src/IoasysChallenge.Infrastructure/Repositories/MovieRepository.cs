using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.Infrastructure.Query.Movies;
using IoasysChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using IoasysChallenge.ApplicationCore.ViewModels;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class MovieRepository : EFRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ImdbContext _repository) 
            :base(_repository)
        {

        }

        public async Task<int> CountMovies()
        {
            return await FindAll().CountAsync();
        }

        public async Task<Movie> GetById(Expression<Func<Movie, bool>> predicate)
        {
            return await _repository.Movies.Where(predicate).SingleOrDefaultAsync();
        }

        public IEnumerable<Movie> List(MovieListViewModel viewModel)
        {
            string vb= "";

            return (IEnumerable<Movie>)_repository.Movies
                            .Include(m => m.MoviesScores)
                            .WithDirector(viewModel.Director)
                            .WithActors(viewModel.Actors)
                            .WithGenre(viewModel.Genre)
                            .WithTitle(viewModel.Title)
                            .GroupBy(m => m.MovieId)
                            //.OrderByDescending(m => m)
                            .Skip(viewModel.Pagination.Start)
                            .Take(viewModel.Pagination.Limit)
                            .ToList();
                            

                            //.ToListAsync();
        }
    }
}
