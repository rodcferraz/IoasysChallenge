using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Services
{
    public interface IServiceMovie
    {
        Task Add(Movie movie);
        Task<Movie> GetByName(string movieTitle);
        Task<Movie> GetById(int movieId);
        Task<int> CountMovies();
        IEnumerable<Movie> List(MovieListViewModel viewModel);
    }
}
