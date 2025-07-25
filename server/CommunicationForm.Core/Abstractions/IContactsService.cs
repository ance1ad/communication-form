using CommunicationForm.Core.Models;

namespace CommunicationForm.Application.Services
{
    public interface IContactsService
    {
        Task<Guid> CreateContact(Contact contact);
        Task<bool> DeleteContact(Guid id);
    }
}