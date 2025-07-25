using CommunicationForm.API.Contracts;
using CommunicationForm.Application.Services;
using CommunicationForm.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationForm.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ThemesController: ControllerBase
    {
        private readonly IThemesService _themesService;
        public ThemesController(IThemesService themesService)
        {
            _themesService = themesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ThemesResponse>>> GetThemes()
        {
            var themes = await _themesService.GetAllThemes();
            var response = themes.Select(t => new ThemesResponse(t.Id, t.ThemeName));
            return Ok(response);
        }
        
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateTheme([FromBody] ThemesRequest request)
        {
            var theme = new Theme(Guid.NewGuid(), request.name);
            await _themesService.CreateTheme(theme);
            return Ok(theme);
        }

    }
}
