using DAL.Repositories.Interfaces;

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
        IBlogRepository BlogRepository { get; }
        IProjectRepository ProjectRepository { get; }
        IOrderBlogRepository OrderBlogRepository { get; }
        IOrderProjectRepository OrderProjectRepository { get; }
        ITechnologyRepository TechnologyRepository { get; }
        IOrderProjectStatusRepository OrderProjectStatusRepository { get; }
        IProjectORBlogTechnologyRepository ProjectORBlogTechnologyRepository { get;  }
        IPeriodProgressRepository PeriodProgressRepository { get; }
    }
}
