using AddressBook.Application.Repositories;
using AddressBook.Application.Services;
using AddressBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private IRepository<Contact, string> _repository;
        public ContactService(IRepository<Contact, string> repository)
        {
            _repository = repository;
        }
        public async Task Create(Application.ApplicationModels.Contact appContact)
        {
            var domainContact = MappingHelpers.MapperExtension.MapTo<Contact>(appContact);

            await _repository.CreateAsync(domainContact);
        }

        public async Task DeleteContact(Application.ApplicationModels.Contact appContact)
        {
            var domainModel = MappingHelpers.MapperExtension.MapTo<Contact>(appContact);
            await _repository.DeleteAsync(domainModel);
        }

        public async Task EditContact(Application.ApplicationModels.Contact appContact)
        {
            var domainModel = MappingHelpers.MapperExtension.MapTo<Contact>(appContact);
            await _repository.UpdateAsync(domainModel);
        }

        public async Task<List<Application.ApplicationModels.Contact>> GetAll()
        {
            var task = _repository.ReadAllAsync();
            var domainContacts = await task;
            var appContacts = domainContacts.Select(c => MappingHelpers.MapperExtension.MapTo<Application
                                                                 .ApplicationModels.Contact>(c)).ToList();
            return appContacts;
        }

        public async Task<Application.ApplicationModels.Contact> GetSingle(string email)
        {
            var task = _repository.ReadByEmailAsync(email);
            var domainContact = await task;
            var appContact = MappingHelpers.MapperExtension.MapTo<Application.ApplicationModels.Contact>(domainContact);
            return appContact;
        }
    }
}
