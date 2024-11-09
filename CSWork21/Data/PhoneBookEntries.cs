using CSWork21.Contexts;
using CSWork21.Enities;
using CSWork21.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CSWork21.Data
{
    public class PhoneBookEntries : IPhoneBookEntries
    {
        private readonly PhoneBookDbContext _context;

        public PhoneBookEntries(PhoneBookDbContext context)
        {
            _context = context;
        }

        public Contact GetContactByID(int id)
        {
            return _context.Contacts.First<Contact>(c => c.Id == id);
        }

        public void EditContact(Contact contact)
        {
            Contact editingContact = GetContactByID(contact.Id);
            editingContact.FirstName = contact.FirstName;
            editingContact.LastName = contact.LastName;
            editingContact.ThirdName = contact.ThirdName;
            editingContact.Phone = contact.Phone;
            editingContact.Address = contact.Address;
            editingContact.Desc = contact.Desc;
            _context.SaveChanges();
        }

        public void AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public void RemoveContact(int id)
        {
            _context.Contacts.Remove(GetContactByID(id));
            _context.SaveChanges();
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _context.Contacts;
        }
    }
}
