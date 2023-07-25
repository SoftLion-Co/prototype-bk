using BLL.DTOs.CountryDTO;
using BLL.DTOs.Response.ResponseEntity;
using MediatR;

namespace BLL.MediatR.Country.DeleteCountry
{
    public record DeleteCountryCommand(Guid Id): IRequest<ResponseEntity>;
}
