using CommunicationForm.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;

        public Guid ContactId { get; set; }           
        public ContactEntity Contact { get; set; }   

        public Guid ThemeId { get; set; }
        public ThemeEntity Theme { get; set; }
    }

}
