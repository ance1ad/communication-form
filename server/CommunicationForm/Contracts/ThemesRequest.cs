using System.ComponentModel.DataAnnotations;

namespace CommunicationForm.API.Contracts
{
    public record ThemesRequest
    (
        [Required(ErrorMessage = "Тема обязательна")]
        string name
    );
    
}
