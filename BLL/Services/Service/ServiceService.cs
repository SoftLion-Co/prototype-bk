
using AutoMapper;
using BLL.DTOs.ServiceDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;

namespace BLL.Services.Service
{
    public class ServiceService : IServiceService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public ServiceService(IMapper mapper, IWrapperRepository repository)
        {
            _mapper = mapper;
            _wrapperRepository = repository;
        }
        public async Task<ResponseEntity> DeleteServiceByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.ServiceRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.Service>();
            await _wrapperRepository.ServiceRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetServiceDTO>>> GetAllCountriesAsync()
        {
            var countries = await _wrapperRepository.ServiceRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetServiceDTO>>(countries);
            return new ResponseEntity<IEnumerable<GetServiceDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetServiceDTO>> GetServiceByIdAsync(Guid id)
        {
            var country = await _wrapperRepository.ServiceRepository.FindByIdAsync(id);
            return country is null
                ? throw NotFoundException.Default<DAL.Entities.Service>()
                : new ResponseEntity<GetServiceDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetServiceDTO>(country));
        }

        public async Task<ResponseEntity<GetServiceDTO>> InsertServiceAsync(InsertServiceDTO insertServiceDTO)
        {
            var country = await _wrapperRepository.ServiceRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Service>(insertServiceDTO));
            await _wrapperRepository.Save();

            return new ResponseEntity<GetServiceDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetServiceDTO>(country));
        }

        public async Task<ResponseEntity<GetServiceDTO>> UpdateServiceAsync(UpdateServiceDTO updateServiceDTO)
        {
            var country = await _wrapperRepository.ServiceRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Service>(updateServiceDTO));
            await _wrapperRepository.Save();

            return new ResponseEntity<GetServiceDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetServiceDTO>(country));
        }
    }
}
