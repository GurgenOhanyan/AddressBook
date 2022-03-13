using AddressBook.Application.Repositories;
using AddressBook.Domain.Entities;
using AddressBook.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Infrastructure.Repositories
{
    public class ContactRepository : IRepository<Contact, int>
    {
        private AddressBookContext _bookContext;
        public ContactRepository(AddressBookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task CreateAsync(Contact entity)
        {
            await _bookContext.Contacts.AddAsync(entity);
            await _bookContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            _bookContext.Contacts.Remove(_bookContext.Contacts.Find(Id));
            await _bookContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> ReadAllAsync()
        {
            var task = _bookContext.Contacts.ToListAsync();
            var allContacts = await task;
            return allContacts;
        }
        public async Task<Contact> ReadByIdAsync(int Id)
        {
            var task = _bookContext.Contacts.Where(m => m.Id == Id).FirstOrDefaultAsync();
            var contact = await task;
            return contact;
        }

        public async Task UpdateAsync(Contact entity)
        {

            var contact = _bookContext.Contacts.FirstOrDefault(c => c.Id == entity.Id);
            contact.EmailAddress = entity.EmailAddress;
            contact.FullName = entity.FullName;
            contact.PhoneNumber = entity.PhoneNumber;
            contact.PhysicalAddress = entity.PhysicalAddress;
            await _bookContext.SaveChangesAsync();
        }
    }
}
