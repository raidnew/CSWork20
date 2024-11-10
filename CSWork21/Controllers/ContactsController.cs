using CSWork21.Enities;
using CSWork21.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace CSWork21.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private IPhoneBookEntries _phoneBookContext;

        public ContactsController(IPhoneBookEntries phoneBookContext)
        {
            _phoneBookContext = phoneBookContext;
        }

        [HttpGet]
        public IEnumerable<Contact> Get()
        {
            return _phoneBookContext.GetContacts();
        }

        [HttpGet]
        [Route("Id/{id}")]
        public Contact GetContactById(int id)
        {
            return _phoneBookContext.GetContactByID(id);
        }
        [HttpPost]
        public void Post([FromBody] Contact contact)
        {
            _phoneBookContext.EditContact(contact);
        }

        [HttpPut]
        public void Put([FromBody] Contact contact)
        {
            _phoneBookContext.AddContact(contact);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _phoneBookContext.RemoveContact(id);
        }
    }
}
