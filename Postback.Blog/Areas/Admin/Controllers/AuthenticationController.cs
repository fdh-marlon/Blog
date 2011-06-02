using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Postback.Blog.App.Data;
using Postback.Blog.App.Services;
using Postback.Blog.Areas.Admin.Models;
using Postback.Blog.Models;

namespace Postback.Blog.Areas.Admin.Controllers
{
    [AppInit]
    public class AuthenticationController : Controller
    {
        private readonly ICryptographer crypto;
        private readonly IPersistenceSession session;
        private readonly IAuth auth;

        public AuthenticationController(ICryptographer cryptographer, IPersistenceSession session, IAuth auth)
        {
            crypto = cryptographer;
            this.session = session;
            this.auth = auth;
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
                   auth.DoAuth(user.Email, true);
                    if (Request.QueryString["ReturnUrl"] != null)
                    {
                        return Redirect(Request.QueryString["ReturnUrl"]);
                    }
                    return RedirectToAction("index", "dashboard");
                }

                ModelState.AddModelError("Email", "Unknown");
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
