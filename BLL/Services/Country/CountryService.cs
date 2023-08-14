using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Country
{
    public class CountryService : ICountryService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public CountryService(IMapper mapper, IWrapperRepository repository)
        {
            _mapper = mapper;
            _wrapperRepository = repository;
        }
        public async Task<ResponseEntity> DeleteCountryByIdAsync(Guid id)
        {
            await _wrapperRepository.CountryRepository.DeleteEntityByIdAsync(id);

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent, null);
        }

        public async Task<ResponseEntity<IEnumerable<GetCountryDTO>>> GetAllCountriesAsync()
        {
            var countries = await _wrapperRepository.CountryRepository.GetAllInformationQueryableAsync();
            var countriesDTO = await countries.ProjectTo<GetCountryDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetCountryDTO>>(System.Net.HttpStatusCode.OK, null, countriesDTO);
        }

        public async Task<ResponseEntity<GetCountryDTO>> GetCountryByIdAsync(Guid id)
        {
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(id);
            return country is null
                ? throw NotFoundException.Default<DAL.Entities.Country>()
                : new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetCountryDTO>(country));
        }

        public async Task<ResponseEntity<GetCountryDTO>> InsertCountryAsync(InsertCountryDTO insertCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Country>(insertCountryDTO));

            return new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.Created, null, _mapper.Map<GetCountryDTO>(country));
        }

        public async Task<ResponseEntity<GetCountryDTO>> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Country>(updateCountryDTO));

            return new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetCountryDTO>(country));
        }
    }
}