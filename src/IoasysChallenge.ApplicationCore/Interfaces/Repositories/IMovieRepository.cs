using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<int> CountMovies();
        IEnumerable<Movie> List(MovieListViewModel viewModel);
        Task<Movie> GetById(Expression<Func<Movie, bool>> predicate);
    }
}
