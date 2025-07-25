using CommunicationForm.Core.Models;

namespace CommunicationForm.DataAccess.Repositories
{
    public interface IThemesRepository
    {
        Task<Guid> Create(Theme theme);
        Task<List<Theme>> GetAll();
        Task<bool> Update(Theme theme);
        Task<bool> Delete(Guid id);
    }
}