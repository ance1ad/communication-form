using CommunicationForm.Core.Models;

namespace CommunicationForm.Application.Services
{
    public interface IMessagesService
    {
        Task<Guid> CreateMessage(Message message);
        Task<List<Message>> GetAllMessages();

        Task<bool> DeleteMessage(Guid id);
    }
}