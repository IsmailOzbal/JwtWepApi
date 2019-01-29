using System.Net;
using System.Net.Http;

namespace Jwt.Controllers
{
    public class LoginResponse
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpResponseMessage responseMsg { get; set; }
    }
}