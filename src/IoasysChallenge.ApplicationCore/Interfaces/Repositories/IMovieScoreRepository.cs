using IoasysChallenge.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Repositories
{
    public interface IMovieScoreRepository : IRepository<MovieScore>
    {
        Task<MovieScore> UserMovieVote(Expression<Func<MovieScore, bool>> pridicate);
        Task<double> GetMovieAvarageScore(Expression<Func<MovieScore, bool>> pridicate);
    }
}
