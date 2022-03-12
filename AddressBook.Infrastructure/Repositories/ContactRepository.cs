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
    public class ContactRepository : IRepository<Contact, string>
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

        public async Task DeleteAsync(Contact entity)
        {
            _bookContext.Contacts.Remove(entity);
            await _bookContext.SaveChangesAsync();
        }

        public async Task<List<Contact>> ReadAllAsync()
        {
            var task = _bookContext.Contacts.ToListAsync();
            var allContacts = await task;
            return allContacts;
        }
        public async Task<Contact> ReadByEmailAsync(string email)
        {
            var task = _bookContext.Contacts.Where(m => m.EmailAddress == email).FirstOrDefaultAsync();
            var contact = await task;
            return contact;
        }

        public async Task UpdateAsync(Contact entity)
        {
            _bookContext.Contacts.Update(entity);
            await _bookContext.SaveChangesAsync();
        }
    }
}
