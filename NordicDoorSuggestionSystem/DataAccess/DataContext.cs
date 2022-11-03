using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NordicDoorSuggestionSystem.Models;

namespace NordicDoorSuggestionSystem.DataAccess
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>().HasKey(x => x.EmployeeNumber);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DepartmentEntity>().HasKey(x => x.DepartmentID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TeamEntity>().HasKey(x => x.TeamID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuggestionEntity>().HasKey(x => x.SgstnID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SgstnReasonEntity>().HasKey(x => x.ReasonID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CommentEntity>().HasKey(x => x.CommentID);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MediaEntity>().HasKey(x => x.MediaID);
            base.OnModelCreating(modelBuilder);
        }



        public DbSet<SuggestionEntity> Suggestion { get; set; }

        public DbSet<CommentEntity> Comment { get; set; }

        public DbSet<DepartmentEntity> Departments { get; set; }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<MediaEntity> Media { get; set; }
        public DbSet<SgstnReasonEntity> SgstnReason { get; set; }
        public DbSet<TeamEntity> Team { get; set; }

    }

}
