// Type: System.Web.Mvc.AuthorizeAttribute
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System;
using System.Web;

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string Roles { get; set; }
        public override object TypeId { get; }
        public string Users { get; set; }

        #region IAuthorizationFilter Members

        public virtual void OnAuthorization(AuthorizationContext filterContext);

        #endregion

        protected virtual bool AuthorizeCore(HttpContextBase httpContext);
        protected virtual void HandleUnauthorizedRequest(AuthorizationContext filterContext);
        protected virtual HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext);
    }
}
