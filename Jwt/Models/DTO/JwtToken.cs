using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Jwt.Models
{
    public class JwtToken
    {
        public string token { get; set; }

        public DateTime issueDate { get; set; }

        public DateTime expireDate { get; set; }
    }
}