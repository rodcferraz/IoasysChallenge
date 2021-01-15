using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.UI.Web.Services;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
using IoasysChallenge.UI.Web.ViewModels;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using IoasysChallenge.UI.Web.ViewModels.Users;
using AutoMapper;
using IoasysChallenge.UI.Web.ViewModels.MoviesScores;
using IoasysChallenge.UI.Web.ControllerExtensions;

namespace IoasysChallenge.UI.Web.Controller
{
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _serviceUser;
        private readonly IServiceMovieScore _serviceMovieScore;
        private readonly IMapper _mapper;
        public UserController(IServiceUser serviceUser, IServiceMovieScore serviceMovieScore, IMapper mapper)
        {
            _serviceUser = serviceUser;
            _serviceMovieScore = serviceMovieScore;
            _mapper = mapper;
        }

        [HttpPost("/User/Authenticate")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserAuthenticationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            try
            {
                var user = _mapper.Map<User>(viewModel);

                var userDb = await _serviceUser.Authenticate(user);

                if (userDb == null)
                    return NotFound(new { message = "Invalid User or Password" });

                var token = TokenService.GenerateToken(userDb);
                userDb.Password = "";
                return new
                {
                    user = userDb,
                    token = token
                };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPost("/User/Create")]
        [AllowAnonymous]
        public async Task<ActionResult> Create([FromBody] UserCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            try
            {
                var user = _mapper.Map<User>(viewModel);

                await _serviceUser.Add(user);

                return Ok("User created successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpPut("/User/Update")]
        [Authorize]
        public async Task<ActionResult> Update([FromBody] UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            try
            {
                var userDb = await _serviceUser.GetById(user.UserId);
                await _serviceUser.Update(userDb);

                return Ok("User updated successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpDelete("/User/Delete/{id?}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }

            try
            {
                var user = await _serviceUser.GetById(id);
                await _serviceUser.Delete(user);

                return StatusCode(200, "User deleted successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }

        [HttpGet("/User/List")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> List(PaginationViewModel viewModel)
        {
            try
            {
                viewModel.TotalRegistered = await _serviceUser.CountUsers();
                var users = await _serviceUser.List(viewModel);

                Response.HttpContext.Items.ToList();

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(viewModel.Json()));

                return StatusCode(200,users);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        [HttpPost("/User/Vote")]
        [Authorize]
        public async Task<ActionResult> Vote([FromBody] MovieScoreViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.ModelErrors();
            }
            try
            {
                var movieScore = _mapper.Map<MovieScore>(viewModel);

                await _serviceMovieScore.Add(movieScore);

                return Ok("User voted successfully");
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
