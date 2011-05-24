using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Postback.Blog.App.Data;
using Postback.Blog.App.Services;
using Postback.Blog.Models;
using Postback.Blog.ViewModels;

namespace Postback.Blog.Areas.Admin.Controllers
{
    [AppInit]
    public class AuthenticationController : Controller
    {
        private ICryptographer crypto;
        private IPersistenceSession session;

        public AuthenticationController(ICryptographer cryptographer, IPersistenceSession session)
        {
            crypto = cryptographer;
            this.session = session;
        }

        public ActionResult Index()
        {
            return View(new AuthenticationModel());
        }

        [HttpPost]
        public ActionResult Index(AuthenticationModel authentication)
        {
            if (ModelState.IsValid)
            {
                var user = session.Single<User>(u => u.Email == authentication.Email);
                if(user !=null && crypto.GetPasswordHash(authentication.Password,user.PasswordSalt) == user.PasswordHashed)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return RedirectToAction("index", "dashboard");
                }

                ModelState.AddModelError("email", "Unknown");
                if(Request.QueryString["ReturnUr"] != null)
                {
                    return Redirect(Request.QueryString["ReturnUr"]);
                }
                return RedirectToAction("index", "authentication");
            }

            return View("Index", new AuthenticationModel());
        }

        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "authentication");
        }
    }
}
