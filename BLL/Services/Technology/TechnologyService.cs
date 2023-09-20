using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.TechnologyDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Technology
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public TechnologyService(IMapper mapper, IWrapperRepository repository)
        {
            _mapper = mapper;
            _wrapperRepository = repository;
        }
        public async Task<ResponseEntity> DeleteTechnologyByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.TechnologyRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.Blog>();
            await _wrapperRepository.TechnologyRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();
            
            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetTechnologyDTO>>> GetAllTechnologiesAsync()
        {
            var technologies = await _wrapperRepository.TechnologyRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetTechnologyDTO>>(technologies);
            return new ResponseEntity<IEnumerable<GetTechnologyDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> GetTechnologyByIdAsync(Guid id)
        {
            var technology = await _wrapperRepository.TechnologyRepository.FindByIdAsync(id);
            return technology is null
                ? throw NotFoundException.Default<DAL.Entities.Technology>()
                : new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetTechnologyDTO>(technology));
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> InsertTechnologyAsync(InsertTechnologyDTO insertTechnologyDTO)
        {
            var technology = await _wrapperRepository.TechnologyRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Technology>(insertTechnologyDTO));

            return new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetTechnologyDTO>(technology));
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> UpdateTechnologyAsync(UpdateTechnologyDTO updateTechnologyDTO)
        {
            var technology = await _wrapperRepository.TechnologyRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Technology>(updateTechnologyDTO));

            return new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetTechnologyDTO>(technology));
        }
    }
}
