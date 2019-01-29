using Jwt.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using static Jwt.Models.Entities;

namespace Jwt.Controllers
{
    public interface IPhoneBook
    {
        IEnumerable<string> Get();

        IHttpActionResult GetPhoneBookList(string name);

        IHttpActionResult InsertPhoneBook([FromBody]PhoneBook value);

        string DeletePhoneBook(Search mobilNo);
    }
}
