using BLL.DTOs.Base;
using BLL.DTOs.SVG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.BlogDTO
{
    public class GetTopBlogDTO : GetTopBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public GetSVGDTO SVG { get; set; } = null!;
    }
}
