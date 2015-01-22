using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSIRestService.Utilities
{
    /// <summary>
    /// Redirect module that allows specifying a set of .svc urls
    /// by stripping the svc extension off and accessing without it.
    /// 
    /// To use add any non-svc path segments (ie. service.svc should be service)
    /// to the ServiceMap below.
    /// 
    /// Note that any path that uses one of these service map entries needs to 
    /// end with a trailing backslash.
    /// </summary>
    public class ServiceExtensionRemover : IHttpModule
    {

        static readonly List<string> ServiceMap = new List<string> 
        {
              "CSIService"
        };

        public void Dispose()
        {

        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += delegate
            {
                var ctx = HttpContext.Current;
                if (ctx.Request.AppRelativeCurrentExecutionFilePath == null) return;
                var path = ctx.Request.AppRelativeCurrentExecutionFilePath.ToLower();

                foreach (var newPath in from mapPath in ServiceMap where path.Contains("/" + mapPath + "/") || path.EndsWith("/" + mapPath) select path.Replace("/" + mapPath + "/", "/" + mapPath + ".svc/"))
                {
                    ctx.RewritePath(newPath, null, ctx.Request.QueryString.ToString(), false);
                    return;
                }
            };
        }
    }
}