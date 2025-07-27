using CommunicationForm.Core.Models;
using CommunicationForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Repositories
{

    public class MessagesRepository : IMessagesRepository
    {
        private readonly CommunicationFormDbContext _context;

        public MessagesRepository(CommunicationFormDbContext context)
        {
            _context = context;
        }

        public async Task<List<Message>> Get()
        {
            var messageEntities = await _context.Messages
                .Include(m => m.Contact)
                .Include(m => m.Theme)
                .AsNoTracking()
                .ToListAsync();

            var messages = messageEntities
                .Select(m =>
                {
                    var (message, error) = Message.Create(
                        m.Id,
                        m.Text,
                        new Contact(m.Contact.Id, m.Contact.Name, m.Contact.Email, m.Contact.Phone ),
                        new Theme(m.Theme.Id, m.Theme.Theme)
                    );
                    return (message, error);
                })
                .Where(result => string.IsNullOrEmpty(result.error))
                .Select(result => result.message!)
                .ToList();
            return messages;
        }


        public async Task<Guid> Create(Message message)
        {
            // Поиск контакта перед созданием
            var existingContact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Email == message.Contact.Email && c.Phone == message.Contact.Phone);

            ContactEntity contactEntity = existingContact ?? new ContactEntity 
            {
                Id = message.Contact.Id,
                Name = message.Contact.Name,
                Email = message.Contact.Email,
                Phone = message.Contact.Phone,
            };

            if (existingContact == null) 
            { 
                _context.Contacts.Add(contactEntity);
                await _context.SaveChangesAsync();

            }

            var themeEntity = await _context.Themes.FindAsync(message.Theme.Id);
            if (themeEntity == null)
            {
                throw new Exception("Тема не найдена");
            }

            var messageEntity = new MessageEntity()
            {
                Id = message.Id,
                Text = message.Text,
                ThemeId = themeEntity.Id,
                ContactId = contactEntity.Id
            };

            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return messageEntity.Id;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Messages.FindAsync(id);
            if (entity == null)
                return false;

            _context.Messages.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
