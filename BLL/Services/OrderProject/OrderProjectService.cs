using AutoMapper;
using BLL.DTOs.OrderProjectDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;

namespace BLL.Services.OrderProject
{
    public class OrderProjectService : IOrderProjectService
    {
        private readonly IWrapperRepository _wrapperRepository;
        
        private readonly IMapper _mapper;

        public OrderProjectService(IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> ChangeTypeOrderAsync(Guid id, bool typeNumber)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.FindByIdAsync(id);
            var changeOrderProject = await _wrapperRepository.OrderProjectRepository.ChangeTypeOrderAsync(orderProject, typeNumber);
            await _wrapperRepository.Save();
            
            return new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderProjectDTO>(changeOrderProject));
        }

        public async Task<ResponseEntity> DeleteOrderProjectByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.OrderProjectRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.OrderProject>();
            await _wrapperRepository.OrderProjectRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();
            
            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetOrderProjectDTO>>> GetAllOrderProjectsAsync()
        {
            var orderProjects = await _wrapperRepository.OrderProjectRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetOrderProjectDTO>>(orderProjects);
            return new ResponseEntity<IEnumerable<GetOrderProjectDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> GetOrderProjectByIdAsync(Guid id)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.FindByIdAsync(id);
            return orderProject is null
                ? throw NotFoundException.Default<DAL.Entities.OrderProject>()
                : new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderProjectDTO>(orderProject));
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> InsertOrderProjectAsync(InsertOrderProjectDTO insertOrderProjectDTO)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.OrderProject>(insertOrderProjectDTO));
            var changeOrderProject = await _wrapperRepository.OrderProjectRepository.NewTypeOrderAsync(orderProject);

            await _wrapperRepository.Save();

            return new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetOrderProjectDTO>(changeOrderProject));
        }
    }
}

