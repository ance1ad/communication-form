using CommunicationForm.Core.Models;

namespace CommunicationForm.DataAccess.Repositories
{
    public interface IMessagesRepository
    {
        Task<Guid> Create(Message message);
        Task<List<Message>> Get();

        Task<bool> Delete(Guid id);
    }
}