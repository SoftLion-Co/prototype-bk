using DAL.Context;
using DAL.GenericRepository;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.WrapperRepository.Interface;


namespace DAL.WrapperRepository
{
    public class WrapperRepository : IWrapperRepository

    {
        private readonly DataContext _context;

        private ICountryRepository? _countryRepository;
        private ISVGRepository? _svgRepository;
        private IPictureRepository? _pictureRepository;
        private IProjectTechnologyRepository?_projectTechnologyRepository;
        private IParagraphRepository? _paragraphRepository;
        private IRatingRepository? _ratingRepository;
        private IAuthorRepository? _authorRepository;
        private IProjectRepository? _projectRepository;
        private IBlogRepository? _blogRepository;
        private IOrderProjectRepository? _orderProjectRepository;
        private IOrderBlogRepository? _orderBlogRepository;
        private ITechnologyRepository? _technologyRepository;
        private IOrderProjectStatusRepository? _orderProjectStatusRepository;
        private IPeriodProgressRepository? _periodProgressRepository;

        public WrapperRepository(DataContext context)
        {
            _context = context;
        }

        public IPeriodProgressRepository PeriodProgressRepository
        {
            get
            {
                if (_periodProgressRepository == null)
                {
                    _periodProgressRepository = new PeriodProgressRepository(_context);
                }
                return _periodProgressRepository;
            }
        }

        public IOrderProjectStatusRepository OrderProjectStatusRepository
        {
            get
            {
                if (_orderProjectStatusRepository == null)
                {
                    _orderProjectStatusRepository = new OrderProjectStatusRepository(_context);
                }
                return _orderProjectStatusRepository;
            }
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

        public IBlogRepository BlogRepository
        {
            get
            {
                if (_blogRepository == null)
                {
                    _blogRepository = new BlogRepository(_context);
                }
                return _blogRepository;
            }
        }

        public IProjectRepository ProjectRepository
        {
            get
            {
                if (_projectRepository == null)
                {
                    _projectRepository = new ProjectRepository(_context);
                }
                return _projectRepository;
            }
        }

        public IOrderBlogRepository OrderBlogRepository
        {
            get
            {
                if (_orderBlogRepository == null)
                {
                    _orderBlogRepository = new OrderBlogRepository(_context);
                }
                return _orderBlogRepository;
            }
        }

        public IOrderProjectRepository OrderProjectRepository
        {
            get
            {
                if (_orderProjectRepository == null)
                {
                    _orderProjectRepository = new OrderProjectRepository(_context);
                }
                return _orderProjectRepository;
            }
        }

        public ITechnologyRepository TechnologyRepository
        {
            get
            {
                if (_technologyRepository == null)
                {
                    _technologyRepository = new TechnologyRepository(_context);
                }
                return _technologyRepository;

            }
        }

        public IProjectTechnologyRepository ProjectTechnologyRepository
        {
            get
            {
                if (_projectTechnologyRepository == null)
                {
                    _projectTechnologyRepository = new ProjectTechnologyRepository(_context);
                }
                return _projectTechnologyRepository;

            }
        }

        

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
