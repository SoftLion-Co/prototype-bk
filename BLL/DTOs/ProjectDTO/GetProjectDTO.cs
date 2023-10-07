using BLL.DTOs.Base;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.CustomerDTO;
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
    public class GetProjectDTO : GetBaseDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Period { get; set; } = null!;
        public int DateYear { get; set; }
        public string RequestDescription { get; set; } = null!;
        public string RequestList { get; set; } = null!;
        public string SolutionDescription { get; set; } = null!;
        public string ResultFirstParagraph { get; set; } = null!;
        public string ResultSecondParagraph { get; set; } = null!;
        public string ResultThirdParagraph { get; set; } = null!;
        public int RatingCount { get; set; }
        public double Mark { get; set; }
        public List<GetPictureDTO> PictureDTOs { get; set; } = null!;
        public List<GetParagraphDTO> ParagraphDTOs { get; set; } = null!;
        public List<GetTechnologyDTO> TechnologyDTOs { get; set; } = null!;
        public GetCountryDTO GetCountryDTO { get; set; } = null!;


    }
}
