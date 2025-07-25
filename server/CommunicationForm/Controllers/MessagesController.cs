using CommunicationForm.API.Contracts;
using CommunicationForm.Application.Services;
using CommunicationForm.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CommunicationForm.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessagesService _messagesService;

        public MessagesController(IMessagesService messagesService)
        {
            _messagesService = messagesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MessagesResponse>>> GetMessages()
        {
            var messages = await _messagesService.GetAllMessages();
            var response = messages.Select(m => new MessagesResponse
            (
                m.Id,
                m.Text,
                new ContactDto(
                    m.Contact.Id,
                    m.Contact.Name,
                    m.Contact.Email,
                    m.Contact.Phone
                ),
                new ThemeDto(
                    m.Theme.Id,
                    m.Theme.ThemeName
                )
            ));
            return Ok(response);
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> CreateMessage([FromBody] MessagesRequest request)
        {
            var contact = new Contact
            (
                Guid.NewGuid(), 
                request.Contact.Name,
                request.Contact.Email,
                request.Contact.Phone
            );

            var theme = new Theme
            (
                request.Theme.Id,
                request.Theme.Name
            );

            var (message, error) = Message.Create
            (
                Guid.NewGuid(),
                request.Text,   
                contact,
                theme
            );

            await _messagesService.CreateMessage(message);
            return Ok(message);
        }
    }
}
