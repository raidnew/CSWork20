using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics.Contracts;
using System.Linq;
using CSWork20.Enities;

namespace CSWork20.Contexts
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("DBPhoneBookContext") { }

        public DbSet<Contact> Contacts { get; set; }

        public Contact GetContactByID(int id)
        {
            Contacts.Load();
            return Contacts.First<Contact>(c => c.Id == id);
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
            SaveChanges();
        }

        public void AddContact(Contact contact) {
            Contacts.Add(contact);
            SaveChanges();
        }

        public void RemoveContact(int id) {
            Contacts.Remove(GetContactByID(id));
            SaveChanges();
        }

    }
}
