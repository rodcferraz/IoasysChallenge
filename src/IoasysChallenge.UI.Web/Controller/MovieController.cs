using AutoMapper;
using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
using IoasysChallenge.ApplicationCore.ViewModels;
using IoasysChallenge.UI.Web.ControllerExtensions;
using IoasysChallenge.UI.Web.ViewModels.Movies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web.Controller
{
    public class MovieCreate
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Duration { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Actors { get; set; }
    }

    public class MovieController : ControllerBase
    {
        private readonly IServiceMovie _serviceMovie;
        private readonly IServiceMovieScore _serviceMovieScore;
        private readonly IMapper _mapper;

        public MovieController(IServiceMovie serviceMovie, IServiceMovieScore serviceMovieScore, IMapper mapper)
        {
            _serviceMovie = serviceMovie;
            _serviceMovieScore = serviceMovieScore;
            _mapper = mapper;
        }

        [HttpPost("/Movie/Create")]
        [Authorize(Roles =("Administrator"))]
        public async Task<ActionResult> Create([FromBody] CreateMovieViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            try
            {
                var movie = _mapper.Map<Movie>(viewModel);
                await _serviceMovie.Add(movie);

                return Ok("Movie created successfully");
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("/Movie/List")]
        [Authorize]
        public async Task<ActionResult> List(MovieListViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            try
            {
                viewModel.Pagination.TotalRegistered = await _serviceMovie.CountMovies();
                var movies =  _serviceMovie.List(viewModel);

                Response.HttpContext.Items.ToList();

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(viewModel.Pagination.Json()));

                return Ok(movies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }

        [HttpGet("/Movie/Details/{id?}")]
        [Authorize]
        public async Task<ActionResult> Details (int id)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            try
            {
                dynamic movie = await _serviceMovie.GetById(id);
                var score = await _serviceMovieScore.GetMovieAvarageScore(id);

                return Ok(new { movie, score });
            }
            catch(DbException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            
        }
    }
}
