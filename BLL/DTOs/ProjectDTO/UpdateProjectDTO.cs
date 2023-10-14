using BLL.DTOs.Base;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.ParagraphDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.TechnologyDTO;

namespace BLL.DTOs.ProjectDTO
{
    public class UpdateProjectDTO : UpdateBaseDTO
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
        public List<UpdatePictureDTO> Pictures { get; set; } = null!;
        public List<UpdateParagraphDTO> Paragraphs { get; set; } = null!;
        public List<UpdateTechnologyDTO> Technologies { get; set; } = null!;
        public UpdateCountryDTO Country { get; set; } = null!;
    }
}
