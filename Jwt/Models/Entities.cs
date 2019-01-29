using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Jwt.Models
{
    public class Entities
    {
        public class User
        {
            [Key]
            public int UserId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public bool IsActive { get; set; }
        }

        public class PhoneBook
        {
            [Key]
            public int PhoneBookId { get; set; }
            public int User_Id { get; set; }
            public string Name_Surname { get; set; }
            public string Address { get; set; }
            public string MobileNo { get; set; }
        }

        public class LogEnterUser
        {
            [Key]
            public int LogEnterUserId { get; set; }
            public int User_Id { get; set; }
            public DateTime RequestDatetime { get; set; }
            public string RequestController { get; set; }
        }
    }
}