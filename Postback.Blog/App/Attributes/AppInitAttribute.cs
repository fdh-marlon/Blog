using System.Configuration;
using System.Web.Mvc;
using Norm;
using Postback.Blog.Models;

namespace Postback.Blog
{
    public class AppInitAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                using (var db = Mongo.Create(ConfigurationManager.AppSettings["mongo.db"]))
                {
                    var users = db.GetCollection<User>();
                    var count = users.Count();

                    if (count == 0)
                    {
                        filterContext.HttpContext.Response.Redirect("/admin/setup", true);
                    }
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}