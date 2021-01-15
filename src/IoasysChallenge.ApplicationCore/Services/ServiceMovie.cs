using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
using IoasysChallenge.ApplicationCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Services
{
    public class ServiceMovie : IServiceMovie
    {
        private readonly IMovieRepository _movieRepository;
        public ServiceMovie(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task Add(Movie movie)
        {
            await _movieRepository.Add(movie);
        }

        public async Task<int> CountMovies()
        {
            return await _movieRepository.CountMovies();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _movieRepository.GetById(id);
        }

        public async Task<Movie> GetByName(string movieTitle)
        {
            return await _movieRepository.GetByName(m => m.Title.Equals(movieTitle));
        }

        public  IEnumerable<Movie> List(MovieListViewModel viewModel)
        {
            return _movieRepository.List(viewModel);
        }
    }
}
