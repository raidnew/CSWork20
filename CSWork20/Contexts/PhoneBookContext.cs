using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using CSWork20.Enities;

namespace CSWork20.Contexts
{
    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext() : base("DBPhoneBookContext") { }

        public DbSet<Contact> Contacts { get; set; }

        public BindingList<Contact> GetItemSourceContacts()
        {
            Contacts.Load();
            return Contacts.Local.ToBindingList();
        }

        public Contact GetContactByID(int id)
        {
            Contacts.Load();
            return Contacts.Single(c => c.Id == id);
        }

    }
}
