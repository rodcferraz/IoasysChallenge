﻿using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.Infrastructure.Query.Movies;
using IoasysChallenge.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;
using IoasysChallenge.ApplicationCore.ViewModels;

namespace IoasysChallenge.Infrastructure.Repositories
{
    public class MovieRepository : EFRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ImdbContext _repository) 
            :base(_repository)
        {

        }

        public async Task<int> CountMovies()
        {
            return await _repository.Movies.CountAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _repository.Movies.Where(m => m.MovieId == id).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Movie>> List(MovieListViewModel viewModel)
        {

            return await _repository.Movies
                            .Include(m => m.MoviesScores)
                            .WithDirector(viewModel.Director)
                            .WithActors(viewModel.Actors)
                            .WithGenre(viewModel.Genre)
                            .WithTitle(viewModel.Title)
                            .OrderBy(m => m.Title)
                            .Skip(viewModel.Pagination.Start)
                            .Take(viewModel.Pagination.Limit)
                            .ToListAsync();

        }
    }
}
