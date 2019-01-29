using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static Jwt.Models.Entities;

namespace Jwt.Controllers.Interface
{
    public interface IUser
    {
        IEnumerable<string> Get();

        IHttpActionResult GetUserList(bool isActive);

        string InsertUser([FromBody]User value);

        string DeleteUser(string Username);
    }
}
