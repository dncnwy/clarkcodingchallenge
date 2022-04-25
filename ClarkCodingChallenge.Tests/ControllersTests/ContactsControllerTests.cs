using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        [TestMethod]
        public void Add_Return_Contact()
        {
            var options = new DbContextOptionsBuilder<MailingListContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            using (var context = new MailingListContext(options))
            {
                context.Contacts.Add(new ContactModel
                {
                    LastName = "Belcher",
                    FirstName = "Bob",
                    Email = "bob@bobsburgers.com"
                });

                context.SaveChanges();
            }

            using (var context = new MailingListContext(options))
            {
                ContactsDataAccess controller = new ContactsDataAccess(context);
                var contact = controller.GetContacts();
                
                Assert.IsNotNull(contact);                

            }
        }
    }
}
