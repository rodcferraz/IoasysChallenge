using AutoMapper;
using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.ApplicationCore.Interfaces.Repositories;
using IoasysChallenge.ApplicationCore.Interfaces.Services;
using IoasysChallenge.ApplicationCore.Services;
using IoasysChallenge.Infrastructure.Data;
using IoasysChallenge.Infrastructure.Repositories;
using IoasysChallenge.UI.Web.ViewModels.Movies;
using IoasysChallenge.UI.Web.ViewModels.MoviesScores;
using IoasysChallenge.UI.Web.ViewModels.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoasysChallenge.UI.Web
{
    public class Startup
    {
        public Startup(IConfiguration _Configuration)
        {
            Configuration = _Configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddNewtonsoftJson(
                    x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


            //MAP CONFIGURATION

            var config = new MapperConfiguration(cfg =>
            {
                //USERS
                cfg.CreateMap<UserAuthenticationViewModel, User>(); 
                cfg.CreateMap<UserViewModel, User>();
                cfg.CreateMap<UserCreateViewModel, User>();

                //MOVIE SCORE
                cfg.CreateMap<MovieScoreViewModel, MovieScore>();

                //MOVIE
                cfg.CreateMap<MovieViewModel, Movie>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);


            // SWAGGER CONFIGURATION

            services.AddSwaggerGen(config => {
                config.SwaggerDoc(
                    "v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title="Teste prático",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name= "Rodrigo Ferraz",
                            Email ="rodcferraz@gmail.com"
                        }
                    }
                    );
            
            });

            // ADD DBCONTEXT 

            services.AddDbContext<ImdbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // AUTHORIZATION

            var key = Encoding.ASCII.GetBytes("ba29e0c3ed8be529ac37cc7da1f52cb4c3825bb88110d00fd891d947f8426c77");
            IdentityModelEventSource.ShowPII = true;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            //DEPENDENCY INJECTION

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IServiceUser, ServiceUser>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IServiceMovie, ServiceMovie>();
            services.AddScoped<IServiceMovieScore, ServiceMovieScore>();
            services.AddScoped<IMovieScoreRepository, MovieScoreRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors(x => x
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(config => {

                config.SwaggerEndpoint("/swagger/v1/swagger.json", "IOASYS");
;            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=User}/{action=Authentication}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=User}/{action=Create}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=User}/{action=Update}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=User}/{action=Delete}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Movie}/{action=Create}"
                );
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Movie}/{action=Details}/{id?}"
                );
            });
        }
    }
}
