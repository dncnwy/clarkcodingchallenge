using ClarkCodingChallenge.DataAccess;
using ClarkCodingChallenge.Models;
using System.Collections.Generic;

namespace ClarkCodingChallenge.BusinessLogic
{
    public interface IContactsService
    {
        ContactModel AddContact(ContactModel model);
        IEnumerable<ContactModel> GetContacts();
    }
    public class ContactsService : IContactsService
    {
        private readonly IContactDataAccess _contactsDataAccess;

        public ContactsService(IContactDataAccess dataAccess)
        {
            _contactsDataAccess = dataAccess;
        }
        //TODO: Place business logic for contact here
        public ContactModel AddContact(ContactModel model)
        {
            _contactsDataAccess.AddContact(model);
            return model;
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            return _contactsDataAccess.GetContacts();
        }
    }
}
