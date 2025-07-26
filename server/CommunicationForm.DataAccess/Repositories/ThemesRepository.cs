using CommunicationForm.Core.Models;
using CommunicationForm.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Repositories
{
    public class ThemesRepository : IThemesRepository
    {
        private readonly CommunicationFormDbContext _context;
        public ThemesRepository(CommunicationFormDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Theme theme)
        {
            // сделать поиск по названию перед добавлением
            var existingTheme = await _context.Themes
                .FirstOrDefaultAsync(t => t.Theme == theme.ThemeName);

            if (existingTheme != null)
            {
                throw new Exception("Такая тема уже существует");
            }

            var themeEntity = new ThemeEntity()
            {
                Id = theme.Id,
                Theme = theme.ThemeName
            };

            await _context.Themes.AddAsync(themeEntity);
            await _context.SaveChangesAsync();
            return themeEntity.Id;
        }

        public async Task<List<Theme>> GetAll()
        {
            var themeEntities = await _context.Themes
                .AsNoTracking()
                .ToListAsync();

            var themes = themeEntities
                .Select(t => Theme.Create(t.Id, t.Theme))
                .Where(result => string.IsNullOrEmpty(result.error))
                .Select(result => result.theme!)
                .ToList();

            return themes;
        }

        public async Task<bool> Update(Theme theme)
        {
            var entity = await _context.Themes.FindAsync(theme.Id);
            if (entity == null)
                return false;

            entity.Theme = theme.ThemeName;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _context.Themes.FindAsync(id);
            if (entity == null)
                return false;

            _context.Themes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
