using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
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

        public async Task<double> GetMovieAvarageScore(int movieId)
        {
            return await _movieScoreRepository.GetMovieAvarageScore(m => m.MovieId == movieId);
        }

        public async Task Update(MovieScore movieScore)
        {
            await _movieScoreRepository.Update(movieScore);
        }

        public async Task<MovieScore> UserMovieVote(MovieScore movieScore)
        {
            return await _movieScoreRepository.UserMovieVote(m => m.UserId == movieScore.UserId && m.MovieId == movieScore.MovieId);
        }
    }
}
