using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WrapperRepository.Interface
{
    public  interface IWrapperRepository
    {
        Task<int> Save();

        ICountryRepository CountryRepository { get; }
        IRatingRepository RatingRepository { get; }
        IPictureRepository PictureRepository { get; }
        ISVGRepository SVGRepository { get; }
        IParagraphRepository ParagraphRepository { get; }
        IAuthorRepository AuthorRepository { get; }

    }
}
