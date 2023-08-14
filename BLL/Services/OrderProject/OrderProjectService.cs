using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.OrderProjectDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ResponseEntity<GetOrderProjectDTO>> ChangeTypeOrderAsync(Guid id, int typeNumber)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.ChangeTypeOrderAsync(id, typeNumber);
            await _wrapperRepository.Save();
            return new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetOrderProjectDTO>(orderProject));

        }

        public async Task<ResponseEntity> DeleteOrderProjectByIdAsync(Guid id)
        {
            await _wrapperRepository.OrderProjectRepository.DeleteEntityByIdAsync(id);

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent, null);
        }

        public async Task<ResponseEntity<IEnumerable<GetOrderProjectDTO>>> GetAllOrderProjectsAsync()
        {
            var orderProjects = await _wrapperRepository.OrderProjectRepository.GetAllInformationQueryableAsync();
            var orderProjectsDTO = await orderProjects.ProjectTo<GetOrderProjectDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetOrderProjectDTO>>(System.Net.HttpStatusCode.OK, null, orderProjectsDTO);
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> GetOrderProjectByIdAsync(Guid id)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.FindByIdAsync(id);
            return orderProject is null
                ? throw NotFoundException.Default<DAL.Entities.OrderProject>()
                : new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetOrderProjectDTO>(orderProject));
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> InsertOrderProjectAsync(InsertOrderProjectDTO insertOrderProjectDTO)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.OrderProject>(insertOrderProjectDTO));

            return new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.Created, null, _mapper.Map<GetOrderProjectDTO>(orderProject));
        }

        public async Task<ResponseEntity<GetOrderProjectDTO>> UpdateOrderProjectAsync(UpdateOrderProjectDTO updateOrderProjectDTO)
        {
            var orderProject = await _wrapperRepository.OrderProjectRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.OrderProject>(updateOrderProjectDTO));

            return new ResponseEntity<GetOrderProjectDTO>(System.Net.HttpStatusCode.OK, null, _mapper.Map<GetOrderProjectDTO>(orderProject));
        }
    }
}

