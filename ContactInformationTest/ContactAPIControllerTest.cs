using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using BusinessLayer;
using DataAccessLayer;
using ContactInformationAPI.Controllers;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
namespace ContactInformationTest
{
    //Unit test cases by using Moq framework 
    [TestClass]
    public class ContactAPIControllerTest
    {
        private Mock<IDataModel> contactRepository;

        [TestMethod]
        public void Get_All_Returns_AllContact()
        {   
            Mock<IDataModel> contactRepository = new Mock<IDataModel>();      
            IEnumerable<contact_info> fakeContacts = GetFakeContacts();
            contactRepository.Setup(x => x.GetContacts()).Returns(fakeContacts);
            ContactController controller = new ContactController(contactRepository.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            // Act
            var contacts = controller.GetContacts();
            // Assert
            Assert.IsNotNull(contacts, "Result is null");
            Assert.AreEqual(HttpStatusCode.OK, contacts.StatusCode);
        }

        [TestMethod]
        public void GetCorrectContactId_Returns_Contact()
        {
            // Arrange   
            Mock<IDataModel> contactRepository = new Mock<IDataModel>();
            IEnumerable<contact_info> fakeCategories = GetFakeContacts();
            contactRepository.Setup(x => x.GetContact(1)).Returns(fakeCategories.FirstOrDefault(x=>x.contact_id==1));
            ContactController controller = new ContactController(contactRepository.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            // Act
            var response = controller.GetContact(1);
            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Get_InvalidContactId_Returns_NotFound()
        {
            // Arrange   
            Mock<IDataModel> contactRepository = new Mock<IDataModel>();
            IEnumerable<contact_info> fakeCategories = GetFakeContacts();
            contactRepository.Setup(x => x.GetContact(1)).Returns(fakeCategories.FirstOrDefault(x => x.contact_id == 99));
            ContactController controller = new ContactController(contactRepository.Object)
            {
                Request = new HttpRequestMessage()
                {
                    Properties = { { HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration() } }
                }
            };
            // Act
            var response = controller.GetContact(99);
            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        private static IEnumerable<contact_info> GetFakeContacts()
        {
            IEnumerable<contact_info> fakeContacts = new List<contact_info> {
                new contact_info {contact_id=1, first_name = "Michael", last_name="Fernando", phone_no="967777",email="test1@gmail.com",status=true},
                new contact_info {contact_id=1, first_name = "Jiah", last_name="Ezra", phone_no="58588",email="test2@gmail.com",status=true},    
            }.AsEnumerable();

            return fakeContacts;
        }
    }
}
