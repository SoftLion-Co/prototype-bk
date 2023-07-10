namespace DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; }
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = null;
        }
    }
}
