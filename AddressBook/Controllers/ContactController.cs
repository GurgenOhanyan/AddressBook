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
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var task = _contactFactory.GetAll();
            var contacts = await task;

            return View(contacts);
        }
        [HttpGet]
        public async Task<IActionResult> GetSingle(int id)
        {
            var task = _contactFactory.GetSingle(id);
            var contact = await task;

            return View(contact);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Create(contact);
            }
            return RedirectToAction("GetAll");
        }
        [HttpGet]
        public IActionResult Edit(Contact contact)
        {
            return View(contact);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(Contact contact)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Update(contact);
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                await _contactFactory.Delete(id);
            }
            return RedirectToAction("GetAll");
        }
    }
}
