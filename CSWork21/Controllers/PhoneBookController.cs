using CSWork21.Contexts;
using CSWork21.Data;
using CSWork21.Enities;
using CSWork21.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CSWork21.Controllers
{
    [Authorize]
    public class PhoneBookController : Controller
    {
        
        private IPhoneBookEntries _phoneBookContext;

        public PhoneBookController(IPhoneBookEntries phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [AllowAnonymous]
        public IActionResult ContactsList()
        {
            ViewBag.contacts = _phoneBookContext.GetContacts();
            return View();
        }

        [HttpGet, AllowAnonymous]
        public IActionResult ContactInfo(int id)
        {
            ViewBag.contact = _phoneBookContext.GetContactByID(id);
            return View();
        }

        [HttpGet, Authorize(Roles = "administrator")]
        public IActionResult ContactEdit(int id)
        {
            ViewBag.contact = _phoneBookContext.GetContactByID(id);
            return View();
        }

        [HttpPost, Authorize(Roles = "administrator")]
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
            _phoneBookContext.EditContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        [HttpPost, Authorize(Roles = "administrator,user")]
        public IActionResult ContactAdd(string firstName, string lastName, string thirdName, string phone, string address, string desc)
        {
            Contact contact = new Contact();
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.ThirdName = thirdName;
            contact.Phone = phone;
            contact.Address = address;
            contact.Desc = desc;
            _phoneBookContext.AddContact(contact);
            return Redirect("/PhoneBook/ContactsList");
        }

        [HttpGet, Authorize(Roles = "administrator,user")]
        public IActionResult ContactAdding()
        {
            return View();
        }

        [HttpDelete, Authorize(Roles = "administrator")]
        public IActionResult ContactRemove(int id)
        {
            _phoneBookContext.RemoveContact(id);
            return Redirect("/PhoneBook/ContactsList");
        }
    }
}
