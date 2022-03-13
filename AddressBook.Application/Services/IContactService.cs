using AddressBook.Application.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Application.Services
{
    public interface IContactService
    {
        Task Create(Contact contact);
        Task<List<Contact>> GetAll();
        Task<Contact> GetSingle(int Id);
        Task EditContact(Contact contact);
        Task DeleteContact(int Id);
    }
}
