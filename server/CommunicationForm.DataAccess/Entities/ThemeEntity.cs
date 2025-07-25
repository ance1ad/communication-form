using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationForm.DataAccess.Entities
{
    public class ThemeEntity
    {
        public Guid Id { get; set; }
        public string Theme { get; set; } = string.Empty;
    }
}
