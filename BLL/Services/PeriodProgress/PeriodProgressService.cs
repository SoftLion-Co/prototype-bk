using AutoMapper;
using BLL.DTOs.Exceptions;
using BLL.DTOs.PeriodProgressDTO;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;

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
            var periodProgress = await _wrapperRepository.PeriodProgressRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.PeriodProgress>(insertPeriodProgressDTO));

            return new ResponseEntity<GetPeriodProgressDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetPeriodProgressDTO>(periodProgress));
        }

        public async Task<ResponseEntity<GetPeriodProgressDTO>> UpdatePeriodProgressAsync(UpdatePeriodProgressDTO updatePeriodProgressDTO)
        {
            var periodProgress = await _wrapperRepository.PeriodProgressRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.PeriodProgress>(updatePeriodProgressDTO));

            return new ResponseEntity<GetPeriodProgressDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetPeriodProgressDTO>(periodProgress));
        }
    }
}
