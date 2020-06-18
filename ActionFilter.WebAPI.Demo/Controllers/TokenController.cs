using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Web.Http;
using Jose;

namespace ActionFilter.WebAPI.Controllers
{
    [RoutePrefix("Token")]
    public class TokenController : ApiController
    {
        [Route("GetToken")]
        [HttpPost]
        public object Post(LoginRequest loginRequest)
        {
            if (loginRequest != null)
            {
                if (loginRequest.Account == "admin" && loginRequest.Password == "admin")
                {
                    
                    string jwtToken = GenerateToken(loginRequest.Account);
                    return new
                    {
                        status = true,
                        token = jwtToken
                    };

                }

            }

            return new
            {
                status = false,
                token = "Account Or Password Error"
            };

        }
        public string GenerateToken(string userName)
        {
            string secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
            Dictionary<string, Object> claim = new Dictionary<string, Object>();
            claim.Add("Account", userName);
            claim.Add("Exp", DateTime.Now.AddMinutes(Convert.ToInt32("60")).ToString(CultureInfo.InvariantCulture));
            var payload = claim;
            var token = JWT.Encode(payload, Encoding.UTF8.GetBytes(secret), JwsAlgorithm.HS512);
            return token;
        }
    }
    public class LoginRequest
    {

        /// <summary>
        /// 
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// OriginCountry
        /// </summary>
        public string Password { get; set; }
    }
}
