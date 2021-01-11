using Microsoft.AspNetCore.Mvc;
using phonebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace phonebook.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {
        private readonly PhoneBookDbContext _context;
        public ContactController(PhoneBookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAllContact")]

        public IEnumerable<Contact> GetAll()
        {
            return _context.Contacts.ToList();

        }

        [HttpGet()]
        [Route("getContact")]
        public IActionResult GetById(int id)
        {
            var item = _context.Contacts.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
       

        [HttpPost]
        [Route("addContact")]
        public IActionResult Create([FromBody] Contact item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var contact = new Contact()
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                HomePhone = item.HomePhone,
                MobilePhone = item.MobilePhone,
                Address = item.Address
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();


            return Ok(new
            {

                message = "Contact is added successfully."
            });
        }

        [HttpPut()]
        [Route("updateContact")]
        public IActionResult Update(int id, [FromBody] Contact item)
        {
            if (item == null || id == 0)
            {
                return BadRequest();
            }
            var contact = _context.Contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }
            contact.FirstName = item.FirstName;
            contact.LastName = item.LastName;
            contact.HomePhone = item.HomePhone;
            contact.MobilePhone = item.MobilePhone;
            contact.Address = item.Address;

            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Contact is updated successfully."
            });
        }

        [HttpDelete()]
        [Route("deleteContact")]
        public IActionResult Delete(long id)
        {
            var contact = _context.Contacts.FirstOrDefault(t => t.Id == id);

            if (contact == null)
            {
                return NotFound();
            }
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
            return Ok(new
            {
                message = "Contact is deleted successfully."
            });
        }
    }
}