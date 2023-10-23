using BLL.DTOs.Base;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.PictureDTO;
using BLL.DTOs.TechnologyDTO;

namespace BLL.DTOs.ProjectDTO
{
    public class GetTopProjectDTO : GetTopBaseDTO
    {
        public string Title { get; set; } = null!;
        public int DateYear { get; set; }
        public string Description { get; set; } = null!;
        public List<GetTechnologyDTO> Technologies { get; set; } = null!;
        public GetPictureDTO Picture { get; set; } = null!;
        public GetCountryDTO GetCountry { get; set; } = null!;
    }
}
