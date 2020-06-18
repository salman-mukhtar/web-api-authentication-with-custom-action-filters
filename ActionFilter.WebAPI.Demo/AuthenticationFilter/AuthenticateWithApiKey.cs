using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace ActionFilter.WebAPI.AuthenticationFilter
{
    public class AuthenticateWithApiKey : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            bool validKey = false;
            actionContext.Request.Headers.TryGetValues("apikey", out var requestHeaders);

            if (requestHeaders != null)
            {
                if (requestHeaders.FirstOrDefault() == "123456789")
                {
                    validKey = true;
                }
            }

            if (!validKey)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
        }
    }
}