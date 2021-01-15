using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Repositories
{
    public interface IMovieScoreRepository : IRepository<MovieScore>
    {
        Task<MovieScore> UserMovieVote(MovieScore movieScore);
        Task<double> GetMovieAvarageScore(int id);

        Task<IEnumerable<MovieScore>> List(MovieListViewModel viewModel);
    }
}
