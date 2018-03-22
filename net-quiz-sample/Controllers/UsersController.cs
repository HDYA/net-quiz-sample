using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using net_quiz_sample.Models;
using net_quiz_sample.Context;
using System.Configuration;

namespace net_quiz_sample.Controllers
{
    public class UsersController : ApiController
    {
        private QuizDbContext db = new QuizDbContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> GetUsers(string id)
        {
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsers(User uses)
        {
            // Workaround when database is not avaliable
            if (ConfigurationManager.AppSettings["UseEnvironmentDatabase"].Equals("true"))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Entry(uses).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> PostUsers(User user)
        {
            // Workaround when database is not avaliable
            if (ConfigurationManager.AppSettings["UseEnvironmentDatabase"].Equals("true"))
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.Users.Add(user);

                await db.SaveChangesAsync();
            }

            return CreatedAtRoute("DefaultApi", new { id = user.Identifier }, user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersExists(string uid)
        {
            return db.Users.Count(e => e.Identifier.Equals(uid)) > 0;
        }
    }
}