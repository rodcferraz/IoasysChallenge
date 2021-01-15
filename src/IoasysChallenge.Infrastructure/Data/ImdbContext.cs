using IoasysChallenge.ApplicationCore.Entity;
using IoasysChallenge.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.Infrastructure.Data
{
    public class ImdbContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieScore> MovieScores { get; set; }
        public DbSet<User> Users { get; set; }

        public ImdbContext(DbContextOptions<ImdbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new MovieMap());
            modelBuilder.ApplyConfiguration(new MovieScoreMap());
        }


    }
}
