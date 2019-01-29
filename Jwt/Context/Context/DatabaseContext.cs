using Jwt.Context.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using static Jwt.Models.Entities;

namespace Jwt.Context
{
    public class DatabaseContext :DbContext
    {
        private readonly DatabaseContext _context;
        DbContextTransaction transaction;
        public DatabaseContext() :base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        

        public DbSet<User> Users { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }
        public DbSet<LogEnterUser> LogEnterUsers { get; set; }



        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

    }
}