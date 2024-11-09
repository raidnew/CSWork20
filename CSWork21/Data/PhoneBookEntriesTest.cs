using CSWork21.Enities;
using CSWork21.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CSWork21.Data
{
    public class PhoneBookEntriesTest : IPhoneBookEntries
    {
        private static readonly List<Contact> _contacts;
        private static int _lastId;
        static PhoneBookEntriesTest()
        {
            _lastId = 10;
            _contacts = new List<Contact>();

            for (int i = 0; i <= _lastId; i++)
            {
                Contact contact = new Contact();
                contact.Id = i;
                contact.FirstName = $"Name{i}";
                contact.LastName = $"LastName{i}";
                contact.ThirdName = $"ThirdName{i}";
                contact.Phone = $"{i}{i}{i}{i}";
                contact.Address = $"Address{i}";
                contact.Desc = $"Desc{i}";
                _contacts.Add(contact);
            }
        }

        public void AddContact(Contact contact)
        {
            contact.Id = ++_lastId;
            Trace.WriteLine(_lastId);
            _contacts.Add(contact);
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
        }

        public Contact GetContactByID(int id)
        {
            return _contacts.Find(x => x.Id == id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _contacts;
        }

        public void RemoveContact(int id)
        {
            _contacts.Remove(GetContactByID(id));
        }
    }
}
