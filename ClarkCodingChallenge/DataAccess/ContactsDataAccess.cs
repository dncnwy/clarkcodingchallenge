using ClarkCodingChallenge.Models;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.DataAccess
{
    public interface IContactDataAccess
    {
        ContactModel AddContact(ContactModel model);
        IEnumerable<ContactModel> GetContacts();
    }
    public class ContactsDataAccess : IContactDataAccess
    { 
        private readonly MailingListContext _context;
    
        public ContactsDataAccess(MailingListContext context)
        {
            _context = context;
        }
        //TODO: Place data access code here
        public ContactModel AddContact(ContactModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public IEnumerable<ContactModel> GetContacts()
        {
            IEnumerable<ContactModel> contacts = _context.GetContacts();
            return contacts;           
        }
    }
}
