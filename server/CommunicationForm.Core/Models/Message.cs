using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.Core.Models
{
    public class Message
    {
        public Message(Guid id, string text, Contact contact, Theme theme)
        {
            Id = id;
            Text = text;
            Contact = contact;
            Theme = theme;
        }

        // Тут будет содержаться бизнес логика


        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public Contact Contact { get; set; }
        public Theme Theme { get; set; }

        public static (Message? message, string error) Create(Guid id, string text, Contact contact, Theme theme)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return (null, "Текст сообщения не может быть пустым");
            }
            if(contact is null)
            {
                return (null, "Передан пустой контакт");
            }
            if (theme is null)
            {
                return (null, "Передана пустая тема");
            }
            var Message = new Message(id, text, contact, theme);
            return (Message, string.Empty);
        }
    }
}
