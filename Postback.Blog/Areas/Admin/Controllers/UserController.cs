using System.Web.Mvc;

namespace Postback.Blog.Areas.Admin.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
