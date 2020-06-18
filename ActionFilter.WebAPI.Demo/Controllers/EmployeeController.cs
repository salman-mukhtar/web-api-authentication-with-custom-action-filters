using System.Web.Http;
using ActionFilter.WebAPI.AuthenticationFilter;

namespace ActionFilter.WebAPI.Controllers
{
    [RoutePrefix("Employee")]
    public class EmployeeController : ApiController
    {
        [Route("AuthenticateWithApiKey")]
        [AuthenticateWithApiKey]
        [HttpGet]
        public string AuthenticateWithApiKey()
        {
            return "API Key Authentication Successful.";
        }

        [Route("AuthenticateWithJwt")]
        [AuthenticateWithJwt]
        [HttpGet]
        public string AuthenticateWithJwt()
        {
            return "JWT Authentication Successful.";
        }

        [Route("AuthenticateWithLdap")]
        [AuthenticateWithLdap]
        [HttpGet]
        public string AuthenticateWithLdap()
        {
            return "LDAP Authentication Successful.";
        }


    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

    }
}
