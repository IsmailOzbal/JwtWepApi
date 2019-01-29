using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static Jwt.Models.Entities;

namespace Jwt.Context
{
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        public DatabaseInitializer()
        {
            Seed(new DatabaseContext());
        }
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);
            User users = new User
            {
                Name = "Ismail",
                Surname = "Ozbal",
                IsActive = true,
                Username = "ismailozbal",
                Password = "admin"
            };

            if (!context.Users.Any(o => o.Username == users.Username))
            {
                context.Users.Add(users);
                context.SaveChanges();
            }
        }
    }
}