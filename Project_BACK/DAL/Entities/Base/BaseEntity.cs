using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedDateTime { get; set; } = null;
        public BaseEntity() 
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = null;
        }
    }
}
