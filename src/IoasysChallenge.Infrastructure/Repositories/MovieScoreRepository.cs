using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
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

        public async Task<MovieScore> UserMovieVote(Expression<Func<MovieScore, bool>> predicate)
        {
            return await _repository.MovieScores.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task<int> CountMovies()
        {
            return await FindAll().CountAsync();
        }

        public async Task<double> GetMovieAvarageScore(Expression<Func<MovieScore, bool>> predicate)
        {
            return await _repository.MovieScores.Where(predicate).AverageAsync(a => a.Score);
        }
    }
}
