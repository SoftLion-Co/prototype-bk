using BLL.DTOs.Base;


namespace BLL.DTOs.CountryDTO
{
    public class GetCountryDTO : GetBaseDto
    {
        public string Name { get; set; } = null!;

    }
}
