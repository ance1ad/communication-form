using CommunicationForm.Core.Models;
using CommunicationForm.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.Application.Services
{
    public class ThemesService : IThemesService
    {
        private readonly IThemesRepository _themesRepository;

        public ThemesService(IThemesRepository themesRepository)
        {
            _themesRepository = themesRepository;
        }

        public async Task<Guid> CreateTheme(Theme theme)
        {
            return await _themesRepository.Create(theme);
        }


        public async Task<List<Theme>> GetAllThemes()
        {
            return await _themesRepository.GetAll();
        }

        public async Task<bool> UpdateTheme(Theme theme)
        {
            return await _themesRepository.Update(theme);
        }

        public async Task<bool> DeleteTheme(Guid id)
        {
            return await _themesRepository.Delete(id);
        }


    }
}
