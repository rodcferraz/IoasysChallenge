using IoasysChallenge.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.Infrastructure.Mappers
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movie", "dbo");
            builder.HasKey(m => m.MovieId);

            builder.Property(m => m.Title).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Year).IsRequired();
            builder.Property(m => m.Duration).IsRequired();
            builder.Property(m => m.Director).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Genre).HasMaxLength(40).IsRequired();
            builder.Property(m => m.Actors).HasMaxLength(200).IsRequired();
            builder.Property(m => m.IsDeleted);

            builder.HasMany(u => u.MoviesScores).WithOne(u => u.Movie).HasForeignKey(u => u.MovieId);
        }
    }
}
