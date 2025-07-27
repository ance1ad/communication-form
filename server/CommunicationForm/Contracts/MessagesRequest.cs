using System.ComponentModel.DataAnnotations;

namespace CommunicationForm.API.Contracts
{
    public record MessagesRequest 
    (
        [Required(ErrorMessage = "Текст сообщения обязателен")]
        [StringLength(500, ErrorMessage = "Максимальная длина сообщения — 500 символов")]
        string Text,

        [Required]
        ContactDto Contact,

        [Required]
        ThemeDto Theme
    );

}
