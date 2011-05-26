using System.Web.Mvc;
using NUnit.Framework;
using Postback.Blog.Controllers;

namespace Postback.Blog.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            var controller = new HomeController();

            var result = controller.Index() as ViewResult;

            Assert.That(result,Is.Not.Null);
            Assert.That(result.ViewBag.Message, Is.EqualTo("Postback Blog"));
        }
    }
}
