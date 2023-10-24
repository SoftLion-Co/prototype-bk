using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.CountryDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
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
            var entity = await _wrapperRepository.CountryRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.Country>();
            await _wrapperRepository.CountryRepository.DeleteEntityByIdAsync(entity);

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetCountryDTO>>> GetAllCountriesAsync()
        {
            var countries = await _wrapperRepository.CountryRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetCountryDTO>>(countries);
            return new ResponseEntity<IEnumerable<GetCountryDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetCountryDTO>> GetCountryByIdAsync(Guid id)
        {
            var country = await _wrapperRepository.CountryRepository.FindByIdAsync(id);
            return country is null
                ? throw NotFoundException.Default<DAL.Entities.Country>()
                : new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetCountryDTO>(country));
        }

        public async Task<ResponseEntity<GetCountryDTO>> InsertCountryAsync(InsertCountryDTO insertCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Country>(insertCountryDTO));
            await _wrapperRepository.Save();

            return new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetCountryDTO>(country));
        }

        public async Task<ResponseEntity<GetCountryDTO>> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Country>(updateCountryDTO));
            await _wrapperRepository.Save();

            return new ResponseEntity<GetCountryDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetCountryDTO>(country));
        }
    }
}