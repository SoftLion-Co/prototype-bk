using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.WrapperRepository.Interface;

namespace DAL.WrapperRepository
{
    public class WrapperRepository : IWrapperRepository
    {
        private readonly DataContext _context;

        private ICountryRepository _countryRepository;
        private ISVGRepository _svgRepository;
        private IPictureRepository _pictureRepository;
        private IParagraphRepository _paragraphRepository;
        private IRatingRepository _ratingRepository;
        private IAuthorRepository _authorRepository;
        public WrapperRepository(DataContext context)
        {
            _context = context;
        }

        public ICountryRepository CountryRepository
        {
            get
            {
                if (_countryRepository == null)
                {
                    _countryRepository = new CountryRepository(_context);
                }
                return _countryRepository;
            }
        }

        public IRatingRepository RatingRepository
        {
            get
            {
                if (_ratingRepository == null)
                {
                    _ratingRepository = new RatingRepository(_context);
                }
                return _ratingRepository;
            }
        }

        public IPictureRepository PictureRepository {
            get
            {
                if (_pictureRepository == null)
                {
                    _pictureRepository = new PictureRepository(_context);
                }
                return _pictureRepository;
            }
        }

        public ISVGRepository SVGRepository {
            get
            {
                if (_svgRepository == null)
                {
                    _svgRepository = new SVGRepository(_context);
                }
                return _svgRepository;
            }
        }

        public IParagraphRepository ParagraphRepository
        {
            get
            {
                if (_paragraphRepository == null)
                {
                    _paragraphRepository = new ParagraphRepository(_context);
                }
                return _paragraphRepository;
            }
        }

        public IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
                    _authorRepository = new AuthorRepository(_context);
                }
                return _authorRepository;
            }
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
