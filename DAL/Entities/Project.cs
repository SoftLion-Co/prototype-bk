using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Period { get; set; }
        public int DateYear { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public string RequestDescription { get; set; }
        public string RequestList { get; set; }
        public string SolutionDescription { get; set; }
        public string ResultFirstParagraph { get; set; }
        public string ResultSecondParagraph { get; set; }
        public string ResultThirdParagraph { get; set; }
    }
}
