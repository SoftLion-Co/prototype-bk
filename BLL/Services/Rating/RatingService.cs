using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.Exceptions;
using BLL.DTOs.RatingDTO;
using BLL.DTOs.Response;
using DAL.WrapperRepository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IWrapperRepository _wrapperRepository;
        private readonly IMapper _mapper;

        public RatingService(IWrapperRepository wrapperRepository, IMapper mapper)
        {
            _wrapperRepository = wrapperRepository;
            _mapper = mapper;
        }
        public async Task<ResponseEntity<GetRatingDTO>> InsertRatingAsync(InsertRatingDTO model)
        {
            var blog = await _wrapperRepository.BlogRepository.FindByIdAsync(model.BlogId);
            if(blog == null)
            {
                throw NotFoundException.Default<DAL.Entities.Blog>();
            }
            var entity = await _wrapperRepository.RatingRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Rating>(model));
            return new ResponseEntity<GetRatingDTO>(System.Net.HttpStatusCode.Created, _mapper.Map<GetRatingDTO>(entity));
        }

        public async Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsAsync()
        {
            var ratings = await _wrapperRepository.RatingRepository.GetAllAsync();
            var result = _mapper.Map<IEnumerable<GetRatingDTO>>(ratings);
            return new ResponseEntity<IEnumerable<GetRatingDTO>>(System.Net.HttpStatusCode.OK, result);
        }

        public async Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsByBlogIdAsync(Guid blogId)
        {
            var ratings = await _wrapperRepository.RatingRepository.GetAllAsync(predicate: rating => rating.BlogId == blogId);
            var result = _mapper.Map<IEnumerable<GetRatingDTO>>(ratings);
            return new ResponseEntity<IEnumerable<GetRatingDTO>>(System.Net.HttpStatusCode.OK, result);
        }
    }
}
