using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jwt.Controllers;
using System.Web.Http;
using System.Web.Http.Results;
using Jwt.Context.UnitOfWork;
using Moq;
using static Jwt.Models.Entities;
using System.Collections.Generic;
using Jwt.Context.GenericRepository;
using System.Linq;

namespace JwtTest
{
    [TestClass]
    public class PhoneBookGetMethod : ApiController
    {
        [TestMethod]
        public void GetPhoneBookList_Null_Test()
        {
            var controller = new PhoneBookController();
            IHttpActionResult actionResult = controller.GetPhoneBookList("");
            var type = actionResult.GetType();
            var expectedType = typeof(BadRequestErrorMessageResult);
            Assert.AreEqual(type.Name, expectedType.Name);
        }


        [TestMethod]
        public void GetPhoneBookList_Test()
        {

            var PhoneBook = new Mock<IPhoneBook>();

            var controller = new PhoneBookController(PhoneBook.Object);

            var response = controller.GetPhoneBookList("ismailozbal");

            Assert.IsNotNull(response);

        }

    }
}
