using AutoMapper;
using BLL.DTOs.Exceptions;
using BLL.DTOs.OrderProjectStatusDTO;
using BLL.DTOs.PeriodProgressDTO;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.PeriodProgress
{
    public class PeriodProgressService : IPeriodProgressService
    {
        private readonly IWrapperRepository _wrapperRepository;

        private readonly IMapper _mapper;

        public PeriodProgressService(IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }
        public async Task<ResponseEntity> DeletePeriodProgressByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.PeriodProgressRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.PeriodProgress>();
            await _wrapperRepository.PeriodProgressRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetPeriodProgressDTO>>> GetAllPeriodProgresssAsync()
        {
            var periodProgresses = await _wrapperRepository.PeriodProgressRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetPeriodProgressDTO>>(periodProgresses);
            return new ResponseEntity<IEnumerable<GetPeriodProgressDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetPeriodProgressDTO>> GetPeriodProgressByIdAsync(Guid id)
        {
            var periodProgress = await _wrapperRepository.PeriodProgressRepository.FindByIdAsync(id);
            return periodProgress is null
                ? throw NotFoundException.Default<DAL.Entities.PeriodProgress>()
                : new ResponseEntity<GetPeriodProgressDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetPeriodProgressDTO>(periodProgress));
        }

        public async Task<ResponseEntity<GetPeriodProgressDTO>> InsertPeriodProgressAsync(InsertPeriodProgressDTO insertPeriodProgressDTO)
        {
            var periodProgress = _mapper.Map<DAL.Entities.PeriodProgress>(insertPeriodProgressDTO);
            
            var services = await _wrapperRepository.ServiceRepository.GetAllExistingAsync();
            var service = services.FirstOrDefault(x=>x.Title ==insertPeriodProgressDTO.Service.Title);
            if (service == null)
            {
                await _wrapperRepository.ServiceRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Service>(insertPeriodProgressDTO.Service));
            }
            else
            {
                periodProgress.Service = service;
            }

            var result = await _wrapperRepository.PeriodProgressRepository.InsertEntityAsync(periodProgress);
            
            await _wrapperRepository.Save();

            return new ResponseEntity<GetPeriodProgressDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetPeriodProgressDTO>(result));
        }
        public async Task<ResponseEntity<IEnumerable<GetPeriodProgressDTO>>> GetGetPeriodProgressByOPSIdAsync(Guid opsId)
        {
            var ops = await _wrapperRepository.OrderProjectStatusRepository.FindByIdAsync(opsId);

            if (ops == null)
            {
                throw NotFoundException.Default<DAL.Entities.OrderProjectStatus>();
            }

            var periodProgresses = await _wrapperRepository.PeriodProgressRepository.FindByOPSId(opsId);

            if (periodProgresses == null)
            {
                throw NotFoundException.Default<DAL.Entities.OrderProjectStatus>();
            }

            var result = _mapper.Map<IEnumerable<GetPeriodProgressDTO>>(periodProgresses);

            return new ResponseEntity<IEnumerable<GetPeriodProgressDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetPeriodProgressDTO>> UpdatePeriodProgressAsync(UpdatePeriodProgressDTO updatePeriodProgressDTO)
        {
            var periodProgress = _mapper.Map<DAL.Entities.PeriodProgress>(updatePeriodProgressDTO);

            var service = await _wrapperRepository.ServiceRepository.GetEntityByIdAsync(updatePeriodProgressDTO.Service.Id);
            if (service == null)
            {
                await _wrapperRepository.ServiceRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Service>(updatePeriodProgressDTO.Service));
            }
            else
            {
                await _wrapperRepository.ServiceRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Service>(updatePeriodProgressDTO.Service));
                periodProgress.Service = service;
            }

            var result = await _wrapperRepository.PeriodProgressRepository.UploadEntityAsync(periodProgress);

            await _wrapperRepository.Save();

            return new ResponseEntity<GetPeriodProgressDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetPeriodProgressDTO>(result));
        }
    }
}
