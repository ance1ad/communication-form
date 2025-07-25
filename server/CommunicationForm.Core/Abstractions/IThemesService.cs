using CommunicationForm.Core.Models;

namespace CommunicationForm.Application.Services
{
    public interface IThemesService
    {
        Task<Guid> CreateTheme(Theme theme);
        Task<List<Theme>> GetAllThemes();
        Task<bool> UpdateTheme(Theme theme);
        Task<bool> DeleteTheme(Guid id);
    }
}