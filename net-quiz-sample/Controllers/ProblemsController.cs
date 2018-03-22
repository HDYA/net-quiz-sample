using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using net_quiz_sample.Models;
using net_quiz_sample.Context;
using System.Configuration;

namespace net_quiz_sample.Controllers
{
    public class ProblemsController : ApiController
    {
        private QuizDbContext db = new QuizDbContext();
        private Random random = new Random(DateTime.Now.Millisecond);

        // GET: api/Problems
        public IQueryable<Problem> GetProblems()
        {
            if (ConfigurationManager.AppSettings["UseEnvironmentDatabase"].Equals("false"))
            {
                return null;
            }
            else
            {
                return db.Problems;
            }
        }

        // GET: api/Problems/5
        [ResponseType(typeof(Problem))]
        public async Task<IHttpActionResult> GetProblems(int id)
        {
            Problem problem;

            // Workaround when database is not avaliable
            if (ConfigurationManager.AppSettings["UseEnvironmentDatabase"].Equals("false"))
            {
                problem = Problem.DefaultProblems.First();
            }
            else if (id > 0)
            {
                problem = await db.Problems.FindAsync(id);
                if (problem == null)
                {
                    return NotFound();
                }
            }
            else
            {
                int index = random.Next(db.Problems.Count()) + 1;
                problem = await db.Problems.FindAsync(index);
            }

            return Ok(problem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProblemsExists(int id)
        {
            return db.Problems.Count(e => e.Id == id) > 0;
        }
    }
}