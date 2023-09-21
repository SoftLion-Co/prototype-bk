using BLL.DTOs.Base;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.TechnologyDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.ProjectDTO
{
    public class GetTopProjectDTO : GetTopBaseDTO
    {
        public string Title { get; set; } = null!;
        public string Period { get; set; } = null!;
        public int DateYear { get; set; }
        public GetPictureDTO PictureDTO { get; set; } = null!;
        public List<GetTechnologyDTO> TechnologyDTOs { get; set; } = null!;
        public GetCountryDTO GetCountryDTO { get; set; } = null!;
    }
}
