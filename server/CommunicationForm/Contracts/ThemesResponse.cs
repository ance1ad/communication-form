using System.ComponentModel.DataAnnotations;

namespace CommunicationForm.API.Contracts
{
    public record ThemesResponse
    (
        Guid Id,

        [Required(ErrorMessage = "Тема обязательна")]
        string name
    );
}
