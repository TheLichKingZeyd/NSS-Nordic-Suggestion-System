using NordicDoorSuggestionSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<SuggestionEntity> Suggestion { get; set;}
        public DbSet<CommentEntity> Comment {get; set;}
    }
    
}
