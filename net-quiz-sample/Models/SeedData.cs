using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace net_quiz_sample.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Models.QuizDatabaseEntities())
            {
                if (context.Problems.Any())
                {
                    return;
                }
                else
                {
                    context.Problems.Add(
                        new Problems
                        {
                            Id = 1,
                            Content = "How many regions Microsoft Azure has GAed across the globe",
                            Category = "Technology",
                            Difficulty = 0,
                            Options = "[ \"32\", \"36\", \"40\", \"44\" ]",
                            Answer = 1
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}