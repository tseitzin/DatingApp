using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data

{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<UserLike> Likes { get; set; }

        override protected void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.Entity<UserLike>()
                .HasKey(k => new {k.SourceUserId, k.TargetUserId});
            
            builder.Entity<UserLike>()
                .HasOne(s => s.SourceUser)
                .WithMany(l => l.LikedUsers)
                .HasForeignKey(s => s.SourceUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<UserLike>()
                .HasOne(s => s.TargetUser)
                .WithMany(l => l.LikedByUsers)
                .HasForeignKey(s => s.TargetUserId)
                .OnDelete(DeleteBehavior.Cascade); //SQL Server does not like cascade for both, use noaction instead
        }
    }
}