﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.OrderBlogDTO;
using BLL.DTOs.Exceptions;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.OrderBlog
{
    public class OrderBlogService : IOrderBlogService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public OrderBlogService(IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<GetOrderBlogDTO>> ChangeTypeOrderAsync(Guid id, int typeNumber)
        {
            var orderBlog = await _wrapperRepository.OrderBlogRepository.ChangeTypeOrderAsync(id, typeNumber);
            await _wrapperRepository.Save();
            return new ResponseEntity<GetOrderBlogDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderBlogDTO>(orderBlog)) ;

        }

        public async Task<ResponseEntity> DeleteOrderBlogByIdAsync(Guid id)
        {
            var entity = await _wrapperRepository.OrderBlogRepository.FindByIdAsync(id) ?? throw NotFoundException.Default<DAL.Entities.OrderBlog>();
            await _wrapperRepository.OrderBlogRepository.DeleteEntityByIdAsync(entity);
            await _wrapperRepository.Save();
            return new ResponseEntity(System.Net.HttpStatusCode.NoContent);
        }

        public async Task<ResponseEntity<IEnumerable<GetOrderBlogDTO>>> GetAllOrderBlogsAsync()
        {
            var orderBlogs = await _wrapperRepository.OrderBlogRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetOrderBlogDTO>>(orderBlogs);
            return new ResponseEntity<IEnumerable<GetOrderBlogDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<GetOrderBlogDTO>> GetOrderBlogByIdAsync(Guid id)
        {
            var orderBlog = await _wrapperRepository.OrderBlogRepository.FindByIdAsync(id);
            return orderBlog is null
                ? throw NotFoundException.Default<DAL.Entities.OrderBlog>()
                : new ResponseEntity<GetOrderBlogDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderBlogDTO>(orderBlog));
        }

        public async Task<ResponseEntity<GetOrderBlogDTO>> InsertOrderBlogAsync(InsertOrderBlogDTO insertOrderBlogDTO)
        {
            var orderBlog = await _wrapperRepository.OrderBlogRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.OrderBlog>(insertOrderBlogDTO));

            return new ResponseEntity<GetOrderBlogDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetOrderBlogDTO>(orderBlog));
        }

        public async Task<ResponseEntity<GetOrderBlogDTO>> UpdateOrderBlogAsync(UpdateOrderBlogDTO updateOrderBlogDTO)
        {
            var orderBlog = await _wrapperRepository.OrderBlogRepository.UploadEntityAsync(_mapper.Map<DAL.Entities.OrderBlog>(updateOrderBlogDTO));

            return new ResponseEntity<GetOrderBlogDTO>(System.Net.HttpStatusCode.OK, _mapper.Map<GetOrderBlogDTO>(orderBlog));
        }
    }
}

