using CommunicationForm.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CommunicationForm.API.Contracts
{
    public record MessagesResponse
    (
        Guid Id,

        [Required] 
        string Text,
        ContactDto Contact,
        ThemeDto Theme
    );

    public record ContactDto
    (
        Guid Id,

        [Required(ErrorMessage = "Имя обязательно")]
        [StringLength(50, ErrorMessage = "Максимальная длина имени — 50 символов")]
        string Name,

        [Required]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        string Email,

        [Phone(ErrorMessage = "Некорректный формат телефона")]
        string Phone
    );

    public record ThemeDto
    (
        Guid Id,
        string Name
    );

}
