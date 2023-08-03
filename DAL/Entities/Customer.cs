using DAL.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace DAL.Entities
{
    public class Customer : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? LinkedIn { get; set; }
        public string? Facebook { get; set; }
        public string? Google { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public ICollection<Project>? Projects { get; set; }
    }
}
