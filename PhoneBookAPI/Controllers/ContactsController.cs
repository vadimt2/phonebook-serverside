using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBookAPI.Core.Entities;
using PhoneBookAPI.Infrastructure;

namespace PhoneBookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService;

        public ContactsController(IPhoneBookService phoneBookService)
        {
            _phoneBookService = phoneBookService;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            return Ok(await _phoneBookService.Get());
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _phoneBookService.Get(id);

            if (contact == null)
                return NotFound();

            return contact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            if (id != contact.Id)
                return BadRequest();

            try
            {
                var updateContact = await _phoneBookService.Update(id, contact);
                return Ok(updateContact);

            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!await ContactExists(id))
                    return NotFound();
                else
                    return BadRequest(new { message = e });
            }
        }

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contact>> Contact(Contact contact)
        {
            Contact newContact = await _phoneBookService.Add(contact);
            if (newContact != null)
                return CreatedAtAction("GetContact", new { id = contact.Id }, contact);
            else
                return BadRequest();
        }

        // DELETE: api/PContacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var contact = await _phoneBookService.Get(id);
            if (contact == null)
                return NotFound();

            await _phoneBookService.Delete(contact);

            return NoContent();
        }

        private async Task<bool> ContactExists(int id)
        {
            return await _phoneBookService.Get(id) != null;
        }
    }
}
