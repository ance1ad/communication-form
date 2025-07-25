using CommunicationForm.Core.Models;

namespace CommunicationForm.API.Contracts
{
    public record MessagesResponse
    (
        Guid Id,
        string Text,
        ContactDto Contact,
        ThemeDto Theme
    );

    public record ContactDto
    (
        Guid Id,
        string Name,
        string Email,
        string Phone
    );

    public record ThemeDto
    (
        Guid Id,
        string Name
    );

}
