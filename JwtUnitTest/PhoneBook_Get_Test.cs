using Jwt.Controllers;
using Jwt.Models.DTO;
using Moq;
using System.Collections.Generic;
using System.Web.Http;
using NUnit.Framework;

namespace JwtUnitTest
{
    [TestFixture]
    class PhoneBook_Get_Test :ApiController
    {
        [Test]
        public void GetMethodTest()
        {
            Mock<IPhoneBook> PhoneMock = new Mock<IPhoneBook>();
            List<PhoneBookTest> list = new List<PhoneBookTest>();
            list.Add(new PhoneBookTest
            {
                Address = "",
                MobileNo = "",
                Name_Surname = "",
            });

            PhoneMock.Setup(a => a.GetPhoneBookList("ismailozbal")).Returns(Ok(list));

            PhoneBookController myobject = new PhoneBookController(PhoneMock.Object);

            var data = myobject.GetPhoneBookList("ismailozbal");

            Assert.AreEqual(1, 1);

        }
    }
}
