using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactsController : Controller
    {
        private readonly ContactContext _contactContext;
        public ContactsController(ContactContext contactContext)
        {
            this._contactContext = contactContext;
        }
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_contactContext.Contacts);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetSingleContact([FromRoute] Guid id)
        {
            var contact = _contactContext.Contacts.Find(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult AddContact(AddContactRequest addContactRequest) 
        {
            var contact = new Contact()
            {
                Id = Guid.NewGuid(),
                Address = addContactRequest.Address,
                Phone = addContactRequest.Phone,
                Email = addContactRequest.Email,
                FullName = addContactRequest.FullName,
            };
            _contactContext.Contacts.Add(contact);
            _contactContext.SaveChanges();
            return Ok(contact);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateContact([FromRoute] Guid id, AddContactRequest updateContactRequest) 
        {
            var contact = _contactContext.Contacts.Find(id);
            if (contact != null)
            {
                contact.FullName = updateContactRequest.FullName;
                contact.Phone = updateContactRequest.Phone;
                contact.Email = updateContactRequest.Email;
                contact.Address = updateContactRequest.Address;
                _contactContext.SaveChanges();
                return Ok(contact); 
            }
            return NotFound();           
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteContact([FromRoute]Guid id)
        {
            var contact=_contactContext.Contacts.Find(id);
            if (contact!=null)
            {
                _contactContext.Contacts.Remove(contact);
                _contactContext.SaveChanges();
                return Ok(contact);
            }
            return NotFound();
        }
    }
}
