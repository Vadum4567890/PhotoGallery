using Applicant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Infrastructure
{
    public class AppDbContext : DbContext
    {
      
         public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
          
            
            Database.EnsureCreated();
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<AccessCode> AccessCodes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
     

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().HasMany(x => x.RefreshTokens).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}
