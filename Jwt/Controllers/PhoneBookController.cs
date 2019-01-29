using Jwt.Context;
using Jwt.Context.GenericRepository;
using Jwt.Context.UnitOfWork;
using Jwt.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using static Jwt.Models.Entities;

namespace Jwt.Controllers
{
    public class PhoneBookController : ApiController, IPhoneBook
    {
        private IPhoneBook service;
        private IUnitOfWork uow;
        private IGenericRepository<PhoneBook> _phoneBookRepository;
        private IGenericRepository<User> _userRepository;
        public PhoneBookController()
        {
            
                uow = new UnitOfWork(new DatabaseContext());
                _phoneBookRepository = uow.GetRepository<PhoneBook>();
                _userRepository = uow.GetRepository<User>();
                   
        }

        public PhoneBookController(IPhoneBook _service)
        {
            service = _service;
            using (var db = new DatabaseContext())
            {
                uow = new UnitOfWork(db);
                _phoneBookRepository = uow.GetRepository<PhoneBook>();
                _userRepository = uow.GetRepository<User>();
            }
           
        }
       

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/PhoneBook/GetPhoneBookList")]
        [HttpGet]
        public IHttpActionResult GetPhoneBookList(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Enter query string parameter name");
            }
            else
            {
                var data = (from a in _phoneBookRepository.GetAll()
                            join b in _userRepository.GetAll() on a.User_Id equals b.UserId
                            where b.Username == name
                            select new PhoneBookTest
                            {
                                Name_Surname = a.Name_Surname,
                                MobileNo = a.MobileNo,
                                Address = a.Address

                            }).ToList();


                return Ok(data);
            }

        }

        [Route("api/PhoneBook/InsertPhoneBook")]
        [HttpPost]

        // POST api/<controller>
        public IHttpActionResult InsertPhoneBook([FromBody]PhoneBook value)
        {
            try
            {
                _phoneBookRepository.Insert(value);
                uow.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        [Route("api/PhoneBook/DeletePhoneBook")]
        [HttpPost]
        public string DeletePhoneBook([FromBody]Search seacrh)
        {
            try
            {
                var data = _phoneBookRepository.GetAll().Where(a => a.MobileNo == seacrh.name).ToList();

                foreach (var item in data)
                {
                    _phoneBookRepository.Delete(item);
                }
                uow.SaveChanges();

                return "Delete operation completed succesfully";
            }
            catch
            {
                return "Delete operation revaled error";
            }


        }
    }
}