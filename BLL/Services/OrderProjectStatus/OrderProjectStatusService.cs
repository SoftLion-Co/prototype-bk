using AutoMapper;
using BLL.DTOs.Exceptions;
using BLL.DTOs.OrderProjectStatusDTO;
using BLL.DTOs.Response;
using BLL.Services.OrderProjectStatus;
using DAL.Entities;
using DAL.WrapperRepository.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.OrderProjectStatusStatus
{
    public class OrderProjectStatusService : IOrderProjectStatusService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<DAL.Entities.Customer> _userManager;

        public OrderProjectStatusService(IWrapperRepository wrapperRepository, IMapper mapper, UserManager<DAL.Entities.Customer> userManager)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<ResponseEntity<GetOrderProjectStatusDTO>> ChangeTypeAsync(Guid id, int typeNumber)
        {
            var orderProjectStatus = await _wrapperRepository.OrderProjectStatusRepository.FindByIdAsync(id);
            var changeOrderProjectStatus = await _wrapperRepository.OrderProjectStatusRepository.ChangeTypeAsync(orderProjectStatus, typeNumber);
            await _wrapperRepository.Save();

            return new ResponseEntity<GetOrderProjectStatusDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderProjectStatusDTO>(changeOrderProjectStatus));
        }

        public async Task<ResponseEntity> DeleteOrderProjectStatusByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.OrderProjectStatusRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.OrderProjectStatus>();
            await _wrapperRepository.OrderProjectStatusRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();

            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>> GetAllOrderProjectStatusesAsync()
        {
            var orderProjectStatuses = await _wrapperRepository.OrderProjectStatusRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetOrderProjectStatusDTO>>(orderProjectStatuses);
            return new ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>> GetOrderProjectStatusByCustomerIdAsync(Guid customerId)
        {
            var customer = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == customerId);

            if (customer == null)
            {
                throw NotFoundException.Default<DAL.Entities.Customer>();
            }

            var orderProjectStatuses = await _wrapperRepository.OrderProjectStatusRepository.FindByCustomerId(customerId);

            if(orderProjectStatuses == null)
            {
                throw NotFoundException.Default<DAL.Entities.OrderProjectStatus>();
            }

            var result = _mapper.Map<IEnumerable<GetOrderProjectStatusDTO>>(orderProjectStatuses);

            return new ResponseEntity<IEnumerable<GetOrderProjectStatusDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetOrderProjectStatusDTO>> GetOrderProjectStatusByIdAsync(Guid id)
        {
            var orderProjectStatus = await _wrapperRepository.OrderProjectStatusRepository.FindByIdAsync(id);
            return orderProjectStatus is null
                ? throw NotFoundException.Default<DAL.Entities.OrderProjectStatus>()
                : new ResponseEntity<GetOrderProjectStatusDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderProjectStatusDTO>(orderProjectStatus));
        }

        public async Task<ResponseEntity<GetOrderProjectStatusDTO>> InsertOrderProjectStatusAsync(InsertOrderProjectStatusDTO insertOrderProjectStatusDTO)
        {
            var orderProjectStatus = await _wrapperRepository.OrderProjectStatusRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.OrderProjectStatus>(insertOrderProjectStatusDTO));

            await _wrapperRepository.Save();

            return new ResponseEntity<GetOrderProjectStatusDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetOrderProjectStatusDTO>(orderProjectStatus));
        }

        public async Task<ResponseEntity<GetOrderProjectStatusDTO>> UpdateOrderProjectStatusAsync(UpdateOrderProjectStatusDTO updateOrderProjectStatusDTO)
        {
            var orderProjectStatus = await _wrapperRepository.OrderProjectStatusRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.OrderProjectStatus>(updateOrderProjectStatusDTO));
            await _wrapperRepository.Save();

            return new ResponseEntity<GetOrderProjectStatusDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderProjectStatusDTO>(orderProjectStatus));
        }
    }
}
