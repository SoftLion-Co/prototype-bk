using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.TechnologyDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response.ResponseEntity;
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
            await _wrapperRepository.TechnologyRepository.DeleteEntityByIdAsync(id);

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent, null);
        }

        public async Task<ResponseEntity<IEnumerable<GetTechnologyDTO>>> GetAllTechnologiesAsync()
        {
            var technologies = await _wrapperRepository.TechnologyRepository.GetAllInformationAsync();
            var technologiesDTO = await technologies.ProjectTo<GetTechnologyDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetTechnologyDTO>>(System.Net.HttpStatusCode.OK, null, technologiesDTO);
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> GetTechnologyByIdAsync(Guid id)
        {
            var technology = await _wrapperRepository.TechnologyRepository.FindByIdAsync(id);
            return technology is null
                ? throw NotFoundException.Default<DAL.Entities.Technology>()
                : new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetTechnologyDTO>(technology));
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> InsertTechnologyAsync(InsertTechnologyDTO insertTechnologyDTO)
        {
            var technology = await _wrapperRepository.TechnologyRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Technology>(insertTechnologyDTO));

            return new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.Created, null, _mapper.Map<GetTechnologyDTO>(technology));
        }

        public async Task<ResponseEntity<GetTechnologyDTO>> UpdateTechnologyAsync(UpdateTechnologyDTO updateTechnologyDTO)
        {
            var technology = await _wrapperRepository.TechnologyRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.Technology>(updateTechnologyDTO));

            return new ResponseEntity<GetTechnologyDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetTechnologyDTO>(technology));
        }
    }
}
