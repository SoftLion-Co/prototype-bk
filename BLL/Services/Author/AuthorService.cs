using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.AuthorDTO;
using BLL.DTOs.Response.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;
using BLL.DTOs.Exceptions;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace BLL.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public AuthorService(IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> GetAllAuthorsAsync()
        {
            var authors = await _wrapperRepository.AuthorRepository.GetAllInformationAsync();
            var authorDTOs = await authors.ProjectTo<GetAuthorDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetAuthorDTO>>(HttpStatusCode.OK, null, authorDTOs);
        }


        public async Task<ResponseEntity<IEnumerable<GetTopAuthorDTO>>> GetAllTopAuthorsAsync()
        {
            var authors = await _wrapperRepository.AuthorRepository.GetAllInformationAsync(selector: author => new DAL.Entities.Author { Fullname = author.Fullname, Avatar = author.Avatar, Employment = author.Employment, Id = author.Id });
            var response = await authors.ProjectTo<GetTopAuthorDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetTopAuthorDTO>>(HttpStatusCode.OK, null, response);
        }

        public async Task<ResponseEntity<GetAuthorDTO>> GetAuthorByIdAsync(Guid id)
        {
            var author = await _wrapperRepository.AuthorRepository.GetEntityByIdAsync(id);
            if (author is null)
            {
                throw NotFoundException.Default<DAL.Entities.Author>();
            }
            return new ResponseEntity<GetAuthorDTO>(HttpStatusCode.OK, null, _mapper.Map<GetAuthorDTO>(author));
        }

        public async Task<ResponseEntity<GetAuthorDTO>> InsertAuthorAsync(InsertAuthorDTO authorDTO)
        {
            var author = _mapper.Map<InsertAuthorDTO, DAL.Entities.Author>(authorDTO);
            var response = await _wrapperRepository.AuthorRepository.InsertEntityAsync(author);
            //TODO Implement exception handling if something goes wrong with Logger
            await _wrapperRepository.Save();
            return new ResponseEntity<GetAuthorDTO>(HttpStatusCode.Created, null, _mapper.Map<GetAuthorDTO>(response));
        }

        public async Task<ResponseEntity<GetAuthorDTO>> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO)
        {
            var author = _mapper.Map<UpdateAuthorDTO, DAL.Entities.Author>(updateAuthorDTO);
            var response = await _wrapperRepository.AuthorRepository.UploadEntityAsync(author);
            //TODO Implement exception handling if something goes wrong with Logger
            await _wrapperRepository.Save();
            return new ResponseEntity<GetAuthorDTO>(HttpStatusCode.OK, null, _mapper.Map<GetAuthorDTO>(response));
        }

        public async Task<ResponseEntity> DeleteAuthorByIdAsync(Guid id)
        {
            await _wrapperRepository.AuthorRepository.DeleteEntityByIdAsync(id);
            await _wrapperRepository.Save();
            return new ResponseEntity(HttpStatusCode.NoContent, null);
        }
    }
}
