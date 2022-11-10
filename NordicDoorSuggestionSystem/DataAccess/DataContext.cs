using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NordicDoorSuggestionSystem.DataAccess
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(x => x.EmployeeNumber);
            modelBuilder.Entity<Department>().HasKey(x => x.DepartmentID);
            modelBuilder.Entity<Team>().HasKey(x => x.TeamID);
            modelBuilder.Entity<Suggestion>().HasKey(x => x.SuggestionID);
            modelBuilder.Entity<SuggestionReason>().HasKey(x => x.ReasonID);
            modelBuilder.Entity<Comment>().HasKey(x => x.CommentID);
            modelBuilder.Entity<Media>().HasKey(x => x.MediaID);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Suggestion> Suggestion { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<SuggestionReason> SgstnReason { get; set; }
        public DbSet<Team> Team { get; set; }

    }
}
