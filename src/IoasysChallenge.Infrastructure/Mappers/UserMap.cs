using IoasysChallenge.ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoasysChallenge.Infrastructure.Mappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "dbo");
            builder.HasKey(u => u.UserId);

            builder.Property(u => u.UserName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(20).IsRequired();
            builder.Property(u => u.Role).IsRequired();
            builder.Property(m => m.IsDeleted);

            builder.HasMany(u => u.MoviesScores).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        }
    }
}
