using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Customer : BaseEntity/* IdentityUser*/
    {
        public DateTime LastWasOnline { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string NumberPhone { get; set; } = string.Empty;
        public string Email { get; set; } =string.Empty;
        public string Password { get; set; } =string.Empty;
        public string LinkedIn { get; set; } =string.Empty;
        public string Facebook { get; set; } = string.Empty;
        public ICollection<Project> Projects { get; set; }
    }
}
