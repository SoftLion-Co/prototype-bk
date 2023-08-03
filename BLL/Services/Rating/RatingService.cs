using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.DTOs.RatingDTO;
using BLL.DTOs.Response.ResponseEntity;
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

        public async Task<ResponseEntity<GetRatingDTO>> CreateRatingAsync(InsertRatingDTO model)
        {
            var entity = await _wrapperRepository.RatingRepository.InsertEntityAsync(_mapper.Map<DAL.Entities.Rating>(model));
            return new ResponseEntity<GetRatingDTO>(System.Net.HttpStatusCode.Created, null, _mapper.Map<GetRatingDTO>(entity));
        }

        public async Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsAsync()
        {
            var ratings = await _wrapperRepository.RatingRepository.GetAllInformationAsync();
            var response = await ratings.ProjectTo<GetRatingDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetRatingDTO>>(System.Net.HttpStatusCode.OK, null, response);
        }

        public async Task<ResponseEntity<IEnumerable<GetRatingDTO>>> GetAllRatingsByProjectIdAsync(Guid projectId)
        {
            var ratings = await _wrapperRepository.RatingRepository.GetAllInformationAsync(predicate: rating => rating.ProjectId == projectId);
            var response = await ratings.ProjectTo<GetRatingDTO>(_mapper.ConfigurationProvider).ToListAsync();
            return new ResponseEntity<IEnumerable<GetRatingDTO>>(System.Net.HttpStatusCode.OK, null, response);
        }
    }
}
