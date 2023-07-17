using DAL.Entities.Base;

namespace DAL.Entities
{
    public class Customer : BaseEntity/* IdentityUser*/
    {
        public string Fullname { get; set; } = null!;
        public string NumberPhone { get; set; } = null!;
        public string Email { get; set; } =null!;
        public string Password { get; set; } =null!;
        public string LinkedIn { get; set; } =null!;
        public string Facebook { get; set; } = null!;
        public ICollection<Project>? Projects { get; set; }
    }
}
