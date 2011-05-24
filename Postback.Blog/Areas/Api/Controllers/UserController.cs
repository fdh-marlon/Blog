using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Norm;
using Postback.Blog.Models;

namespace Postback.Blog.Areas.Api.Controllers
{
    public class UserController : Controller
    {
        public JsonResult IsUnique(string email)
        {
           using (var db = Mongo.Create(ConfigurationManager.AppSettings["mongo.db"]))
           {
               var collection = db.GetCollection<User>().AsQueryable().Where(u => u.Email == email).Count();
               if (collection == 0)
               {
                   return Json(true, JsonRequestBehavior.AllowGet);
               }

               return Json("That e-mailadres is not unique", JsonRequestBehavior.AllowGet);
           }
        }

    }
}
