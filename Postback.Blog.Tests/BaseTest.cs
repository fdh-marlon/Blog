using Moq;

namespace Postback.Blog.Tests
{
    public class BaseTest
    {
        public static T M<T>() where T : class
        {
            return Mock.Of<T>();
        }
    }
}
