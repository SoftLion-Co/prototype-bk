using DAL.Context;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using DAL.WrapperRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WrapperRepository
{
    internal class WrapperRepository : IWrapperRepository
    {
        private readonly DataContext _context;

        private ICountryRepository _countryRepository;
        private ISVGRepository _svgRepository;
        private IPictureRepository _pictureRepository;
        private IDescriptionRepository _descriptionRepository;
        private IRatingRepository _ratingRepository;

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

        public IDescriptionRepository DescriptionRepository
        {
            get
            {
                if (_descriptionRepository == null)
                {
                    _descriptionRepository = new DescriptionRepository(_context);
                }
                return _descriptionRepository;
            }
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
