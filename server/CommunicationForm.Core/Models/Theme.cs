using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CommunicationForm.Core.Models
{
    public class Theme
    {
        public Theme(Guid Id, string ThemeName)
        {
            this.Id = Id;
            this.ThemeName = ThemeName;
        }


        public Guid Id { get; set; }
        public string ThemeName { get; set; } = string.Empty;



        public static (Theme? theme, string error) Create(Guid id, string themeName)
        {
            if(string.IsNullOrWhiteSpace(themeName))
            {
                return (null, "Передана пустая тема");
            }
            var theme = new Theme(id, themeName);

            return (theme, string.Empty);
        }
    }
}
