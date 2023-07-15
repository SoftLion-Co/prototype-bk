using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Project : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty;
        public int DateYear { get; set; }
        public Guid? CountryId { get; set; }
        public Country? Country { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public string RequestList { get; set; } = string.Empty;
        public string SolutionDescription { get; set; } = string.Empty;
        public string ResultFirstParagraph { get; set; } = string.Empty;
        public string ResultSecondParagraph { get; set; } = string.Empty;
        public string ResultThirdParagraph { get; set; } = string.Empty;
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; } 
        public ICollection<Paragraph> Paragraphs { get; set; } 
        public ICollection<Rating> Ratings { get; set; } 
        public ICollection<Picture> Pictures { get; set; } 



    }
}
