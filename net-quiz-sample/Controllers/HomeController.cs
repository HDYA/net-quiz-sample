using System.Configuration;
using System.Web.Mvc;

namespace net_quiz_sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("<script>window.location = \"" + ConfigurationManager.AppSettings["IndexPagePath"] + "\"</script>");
        }
    }
}
