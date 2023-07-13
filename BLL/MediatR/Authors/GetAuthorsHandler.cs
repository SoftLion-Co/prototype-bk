using AutoMapper;
using BLL.DTOs.RequestDTOs;
using DAL.Entities.ResponseEntity;
using DAL.WrapperRepository.Interface;
using MediatR;

namespace BLL.MediatR.Authors
{
    public class GetAuthorsHandler : IRequestHandler<GetAllAuthorsQuery, ResponseEntity<IEnumerable<AuthorDTO>>>
    {
        private readonly IWrapperRepository _repository;
        private readonly IMapper _mapper;
        public GetAuthorsHandler(IWrapperRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseEntity<IEnumerable<AuthorDTO>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.AuthorRepository.GetAllInformationAsync();
            var authorsDTOs = _mapper.Map<ResponseEntity<IEnumerable<AuthorDTO>>>(authors);
            var rsp = new ResponseEntity<IEnumerable<AuthorDTO>>();

            return authorsDTOs;
        }
    }
}
