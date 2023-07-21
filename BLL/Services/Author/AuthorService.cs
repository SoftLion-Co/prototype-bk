using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

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

            return _mapper.Map<ResponseEntity<IEnumerable<DAL.Entities.Author>>, ResponseEntity<IEnumerable<GetAuthorDTO>>>(authors);
        }

        public async Task<ResponseEntity<GetAuthorDTO>> GetAuthorByIdAsync(Guid id)
        {
            var author = await _wrapperRepository.AuthorRepository.GetEntityByIdAsync(id);

            return _mapper.Map<ResponseEntity<GetAuthorDTO>>(author);
        }

        public async Task<ResponseEntity<GetAuthorDTO>> InsertAuthorAsync(InsertAuthorDTO authorDTO)
        {
            var author = _mapper.Map<InsertAuthorDTO, DAL.Entities.Author>(authorDTO);
            var response = await _wrapperRepository.AuthorRepository.InsertEntityAsync(author);
            //TODO Implement exception handling if something goes wrong with Logger
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<GetAuthorDTO>>(response);
        }

        public async Task<ResponseEntity<GetAuthorDTO>> UpdateAuthorAsync(UpdateAuthorDTO updateAuthorDTO)
        {
            var author = _mapper.Map<UpdateAuthorDTO, DAL.Entities.Author>(updateAuthorDTO);
            var response = await _wrapperRepository.AuthorRepository.UploadEntityAsync(author);
            //TODO Implement exception handling if something goes wrong with Logger
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<GetAuthorDTO>>(response);
        }

        public async Task<ResponseEntity<IEnumerable<GetAuthorDTO>>> DeleteAuthorByIdAsync(Guid id)
        {
            var authors = await _wrapperRepository.AuthorRepository.DeleteEntityByIdAsync(id);
            //TODO Implement exception handling if something goes wrong with Logger
            await _wrapperRepository.Save();
            return _mapper.Map<ResponseEntity<IEnumerable<GetAuthorDTO>>>(authors);
        }

        public async Task<ResponseEntity<IEnumerable<GetTopAuthorDTO>>> GetAllTopAuthorsAsync()
        {
            var authors = await _wrapperRepository.AuthorRepository.GetAllInformationQueryableAsync(selector: author => new DAL.Entities.Author { Name = author.Name, Avatar = author.Avatar, Employment = author.Employment, Id = author.Id });
            var response = await authors.Result.ProjectTo<GetTopAuthorDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetTopAuthorDTO>> { Result = response };
        }
    }
}
