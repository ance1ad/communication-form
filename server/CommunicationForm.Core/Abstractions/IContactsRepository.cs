using CommunicationForm.Core.Models;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Repositories
{
    public interface IContactsRepository
    {
        Task<Guid> Create(Contact contact);
        Task<IEnumerable<Contact>> GetAll();
        Task<bool> Update(Contact contact);
        Task<bool> Delete(Guid id);
    }
}