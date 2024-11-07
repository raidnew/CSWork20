using CSWork20.Contexts;
using CSWork20.Enities;
using Microsoft.AspNetCore.Mvc;

namespace CSWork20.Controllers
{
    public class PhoneBookController : Controller
    {
        public IActionResult ContactsList()
        {
            ViewBag.contacts = new PhoneBookContext().Contacts;
            return View();
        }

        [HttpGet]
        public IActionResult ContactInfo(int id)
        {
            ViewBag.contact = new PhoneBookContext().GetContactByID(id);
            return View();
        }

        [HttpPost]
        public IActionResult ContactEdit(int id, string firstName, string lastName, string thirdName, string phone, string address, string desc)
        {
            Contact contact = new Contact();
            contact.Id = id;
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.ThirdName = thirdName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Desc = desc;
            new PhoneBookContext().EditContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        //[HttpPut]
        public IActionResult ContactAdd(string firstName, string lastName, string thirdName, string phone, string address, string desc)
        {
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.ThirdName = thirdName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Desc = desc;
            new PhoneBookContext().AddContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        public IActionResult ContactAdding()
        {
            return View();
        }

        [HttpDelete]
        public IActionResult ContactRemove(int id)
        {
            new PhoneBookContext().RemoveContact(id);
            return Redirect("/PhoneBook/ContactsList");
        }
    }
}
