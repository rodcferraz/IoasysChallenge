using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.ApplicationCore.ViewModels;
using IoasysChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class MovieScoreRepository : EFRepository<MovieScore>, IMovieScoreRepository
    {
        public MovieScoreRepository(ImdbContext _repository) 
            : base(_repository)
        {

        }

        public async Task<MovieScore> UserMovieVote(MovieScore movieScore)
        {
            return await _repository.MovieScores.Where(m => m.UserId == movieScore.UserId && m.MovieId == movieScore.MovieId).SingleOrDefaultAsync();
        }

        public async Task<int> CountMovies()
        {
            return await FindAll().CountAsync();
        }

        public async Task<double> GetMovieAvarageScore(int id)
        {
            if (await _repository.MovieScores.Where(m => m.MovieId == id).CountAsync() == 0)
            {
                return 0;
            }

            return await _repository.MovieScores.Where(m => m.MovieId == id).AverageAsync(a => a.Score);
        }

        public async Task<IEnumerable<MovieScore>> List(MovieListViewModel viewModel)
        {
            return await _repository.MovieScores.Include(m => m.Movie).Include(m => m.User).Where(m => m.MovieId == 2).ToListAsync();
        }
    }
}
