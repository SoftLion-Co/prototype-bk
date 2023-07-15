using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.AuthorDTO
{
    public class GetTopAuthorDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Employment { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty; 
    }
}
