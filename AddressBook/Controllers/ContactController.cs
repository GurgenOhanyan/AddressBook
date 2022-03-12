using AddressBook.Factory;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Controllers
{
    public class ContactController : Controller
    {
        private IContactFactory _contactFactory;
        public ContactController(IContactFactory contactFactory)
        {
            _contactFactory = contactFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var task = _contactFactory.GetAll();
            var contacts = await task;

            return View(contacts);
        }
        public async Task<IActionResult> GetSingle(string email)
        {
            var task = _contactFactory.GetSingle(email);
            var contact = await task;

            return View(contact);
        }
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Create(contact);
            }
            return Ok();
        }
        public async Task<IActionResult> Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Update(contact);
            }
            return Ok();
        }
        public async Task<IActionResult> Delete(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Delete(contact);
            }
            return Ok();
        }
    }
}
