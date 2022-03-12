using AddressBook.Application.Services;
using AddressBook.Factory.MappingHelpers;
using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Factory
{
    public class ContactFactory : IContactFactory
    {
        private IContactService _contactService;
        public ContactFactory(IContactService contactService)
        {
            _contactService = contactService;
        }
        public async Task Create(Contact contact)
        {
            await _contactService.Create(MapperExtension.MapTo<Application.ApplicationModels.Contact>(contact));
        }

        public async Task Delete(Contact contact)
        {
            await _contactService.DeleteContact(MapperExtension.MapTo<Application.ApplicationModels.Contact>(contact));
        }

        public async Task<List<Contact>> GetAll()
        {
            var task = _contactService.GetAll();
            var allAppContacts = await task;
            var contacts = allAppContacts.Select(c => MapperExtension.MapTo<Contact>(c)).ToList();
            return contacts;
        }

        public async Task<Contact> GetSingle(string email)
        {
            var task = _contactService.GetSingle(email);
            var appContact = await task;
            var contact = MapperExtension.MapTo<Contact>(appContact);
            return contact;
        }

        public async Task Update(Contact contact)
        {
            await _contactService.EditContact(MapperExtension.MapTo<Application.ApplicationModels.Contact>(contact));
        }
    }
}
