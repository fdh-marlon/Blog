using Postback.Blog.App.Data;
using StructureMap.Configuration.DSL;

namespace Postback.Blog.App.DependencyResolution
{
    public class AppRegistry : Registry
    {
        public AppRegistry()
        {
            For<IPersistenceSession>()
                .Use<MongoSession>();
        }
    }
}