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
    public class ServiceMovieScore : IServiceMovieScore
    {
        private readonly IMovieScoreRepository _movieScoreRepository;

        public ServiceMovieScore(IMovieScoreRepository movieScoreRepository)
        {
            _movieScoreRepository = movieScoreRepository;
        }

        public async Task Add(MovieScore movieScore)
        {
            await _movieScoreRepository.Add(movieScore);
        }

        public async Task<double> GetMovieAvarageScore(int id)
        {
            return await _movieScoreRepository.GetMovieAvarageScore(id);
        }

        public async Task<IEnumerable<MovieScore>> List(MovieListViewModel viewModel)
        {
            return await _movieScoreRepository.List(viewModel);
        }

        public async Task Update(MovieScore movieScore)
        {
            await _movieScoreRepository.Update(movieScore);
        }

        public async Task<MovieScore> UserMovieVote(MovieScore movieScore)
        {
            return await _movieScoreRepository.UserMovieVote(movieScore);
        }
    }
}
