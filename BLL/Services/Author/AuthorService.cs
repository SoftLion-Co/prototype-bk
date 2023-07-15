using AutoMapper;
using BLL.DTOs.AuthorDTO;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;

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
    }
}
