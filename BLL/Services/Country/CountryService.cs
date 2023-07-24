using AutoMapper;
using BLL.DTOs.CountryDTO;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;

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
        public async Task<ResponseEntity<IEnumerable<GetCountryDTO>>> DeleteCountryByIdAsync(Guid id)
        {
            var countries = await _wrapperRepository.CountryRepository.DeleteEntityByIdAsync(id);

            return _mapper.Map<ResponseEntity<IEnumerable<GetCountryDTO>>>(countries);
        }

        public async Task<ResponseEntity<IEnumerable<GetCountryDTO>>> GetAllCountriesAsync()
        {
            var countries = await _wrapperRepository.CountryRepository.GetAllInformationAsync();

            return _mapper.Map<ResponseEntity<IEnumerable<GetCountryDTO>>>(countries);
        }

        public async Task<ResponseEntity<GetCountryDTO>> GetCountryByIdAsync(Guid id)
        {
            var countries = await _wrapperRepository.CountryRepository.FindByIdAsync(id);

            return _mapper.Map<ResponseEntity<GetCountryDTO>>(countries);
        }

        public async Task<ResponseEntity<GetCountryDTO>> InsertCountryAsync(InsertCountryDTO insertCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Country>(insertCountryDTO));

            return _mapper.Map<ResponseEntity<GetCountryDTO>>(country);
        }

        public async Task<ResponseEntity<GetCountryDTO>> UpdateCountryAsync(UpdateCountryDTO updateCountryDTO)
        {
            var country = await _wrapperRepository.CountryRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Country>(updateCountryDTO));

            return _mapper.Map<ResponseEntity<GetCountryDTO>>(country);
        }
    }
}
