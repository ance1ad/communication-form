using CommunicationForm.Core.Models;
using CommunicationForm.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.Application.Services
{

    // Будет использовать репозитории и  с их помощью работать с данными
    public class ContactsService : IContactsService
    {
        private readonly IContactsRepository _contactRepository;

        public ContactsService(IContactsRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Guid> CreateContact(Contact contact)
        {
            return await _contactRepository.Create(contact);
        }

        public async Task<bool> DeleteContact(Guid id)
        {
            return await _contactRepository.Delete(id);

        }
    }
}
