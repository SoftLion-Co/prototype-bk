using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Picture : BaseEntity
    {
        public byte[] Content { get; set; } = null!;

    }
}
