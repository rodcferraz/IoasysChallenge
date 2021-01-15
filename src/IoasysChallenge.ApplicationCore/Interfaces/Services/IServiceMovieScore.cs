using IoasysChallenge.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.ApplicationCore.Interfaces.Services
{
    public interface IServiceMovieScore
    {
        Task Add(MovieScore movieScore);
        Task Update(MovieScore movieScore);
        Task<MovieScore> UserMovieVote(MovieScore movieScore);
        Task<double> GetMovieAvarageScore(int movieId);

    }
}
