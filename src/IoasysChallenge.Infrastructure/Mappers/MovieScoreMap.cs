using IoasysChallenge.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.Infrastructure.Mappers
{
    public class MovieScoreMap : IEntityTypeConfiguration<MovieScore>
    {
        public void Configure(EntityTypeBuilder<MovieScore> builder)
        {
            builder.ToTable("MovieScore","dbo");
            builder.HasKey(m => new { m.MovieId, m.UserId });

            builder.Property(m => m.Score).IsRequired();

            builder.HasOne(m => m.User).WithMany(m => m.MoviesScores).HasForeignKey(m => m.UserId);
            builder.HasOne(m => m.Movie).WithMany(m => m.MoviesScores).HasForeignKey(m => m.MovieId);
        }
    }
}
