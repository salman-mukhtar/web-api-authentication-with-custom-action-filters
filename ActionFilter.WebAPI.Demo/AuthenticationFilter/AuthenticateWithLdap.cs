using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Controllers;

namespace ActionFilter.WebAPI.AuthenticationFilter
{
    public class AuthenticateWithLdap : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                var authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                var userName = decodedToken.Substring(0, decodedToken.IndexOf(":", StringComparison.Ordinal));
                var userPassword = decodedToken.Substring(decodedToken.IndexOf(":", StringComparison.Ordinal) + 1);

                //You can use ldap here to verify user
                if (userName == "ldap_user" && userPassword == "ldap_password")
                {
                    //Authorized
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.Unauthorized,
                        Content = new StringContent("You are unauthorized to access this resource")
                    };
                }
            }
        }
    }
}