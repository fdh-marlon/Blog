using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Postback.Blog.App.Data;
using Postback.Blog.App.Repositories;
using Postback.Blog.Models;

namespace Postback.Blog.Controllers
{
    public class HomeController : Controller
    {
        private IPersistenceSession session;

        public HomeController(IPersistenceSession session)
        {
            this.session = session;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Postback Blog";

            return View(session.All<Post>().OrderByDescending(p => p.Created).ToList());
        }
    }
}
