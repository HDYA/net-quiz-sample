using net_quiz_sample.Models;
using System.Data.Entity;

namespace net_quiz_sample.Context
{
    public class QuizDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Problem> Problems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}