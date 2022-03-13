using AddressBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBook.Factory
{
    public interface IContactFactory
    {
        Task Create(Contact contact);
        Task<List<Contact>> GetAll();
        Task<Contact> GetSingle(int Id);
        Task Update(Contact contact);
        Task Delete(int Id);
    }
}
