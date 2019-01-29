using Jwt.Context;
using Jwt.Context.GenericRepository;
using Jwt.Context.UnitOfWork;
using Jwt.Controllers.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using static Jwt.Models.Entities;

namespace Jwt.Controllers
{

    public class UserController : ApiController,IUser
    {
        private IUser service;
        private IUnitOfWork uow;
        private IGenericRepository<User> _userRepository;
        public UserController()
        {
            uow = new UnitOfWork(new DatabaseContext());
            _userRepository = uow.GetRepository<User>();
        }

        public UserController(IUser _service)
        {
            service = _service;
            uow = new UnitOfWork(new DatabaseContext());
            _userRepository = uow.GetRepository<User>();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/User/GetUserList")]
        [HttpGet]
        public IHttpActionResult GetUserList(bool isActive)
        {
           
                var data = (from a in _userRepository.GetAll()
                            where a.IsActive==isActive
                            select new
                            {
                               a.UserId,
                               a.Name,
                               a.Surname,
                               a.Username,
                               a.IsActive

                            }).ToList();


                return Ok(data);
            
        }

        [Route("api/User/InsertUser")]
        [HttpPost]
        // POST api/<controller>
        public string InsertUser([FromBody]User value)
        {
            try
            {
                _userRepository.Insert(value);
                uow.SaveChanges();
                return "User saved succesfully";
            }
            catch
            {
                return "User didn't save.";
            }

        }

        [Route("api/User/DeleteUser")]
        [HttpDelete]
        // DELETE api/<controller>/5
        public string DeleteUser(string Username)
        {
            try
            {
                var data = _userRepository.GetAll().Where(a => a.Username == Username).ToList();

                foreach (var item in data)
                {
                    _userRepository.Delete(item);
                }
                uow.SaveChanges();

                return "User deleted succesfully";
            }
            catch
            {
                return "User didn't deleted.Some problem occurs";
            }


        }


    }
}