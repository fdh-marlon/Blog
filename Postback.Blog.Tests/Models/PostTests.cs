using NUnit.Framework;
using Postback.Blog.Models;

namespace Postback.Blog.Tests.Models
{
    [TestFixture]
    public class PostTests
    {
        [Test]
        public void ConstructorWithNameSetsUri()
        {
            var post = new Post("The long title");
            Assert.That(post.Uri, Is.EqualTo(post.Title.ToUri()));
        }
    }
}
