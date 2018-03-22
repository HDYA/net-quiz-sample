using net_quiz_sample.Models;
using System.Linq;

namespace net_quiz_sample.Context
{
    public class QuizInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<QuizDbContext>
    {
        protected override void Seed(QuizDbContext context)
        {
            if (context.Problems.Any())
            {
                return;
            }
            else
            {
                context.Problems.AddRange(Problem.DefaultProblems);
                context.Users.AddRange(User.DefaultUsers);
                context.SaveChanges();
            }
        }
    }
}