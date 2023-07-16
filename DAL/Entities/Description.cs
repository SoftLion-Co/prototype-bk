using DAL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Description : BaseEntity
    {
        public string Text { get; set; } = null!;
    }
}
