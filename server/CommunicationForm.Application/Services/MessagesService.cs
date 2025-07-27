using CommunicationForm.Core.Models;
using CommunicationForm.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.Application.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IMessagesRepository _messageRepository;

        public MessagesService(IMessagesRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Guid> CreateMessage(Message message)
        {
            return await _messageRepository.Create(message);
        }

        public async Task<bool> DeleteMessage(Guid id)
        {
            return await _messageRepository.Delete(id);
        }


        public async Task<List<Message>> GetAllMessages()
        {
            return await _messageRepository.Get();
        }

    }
}
