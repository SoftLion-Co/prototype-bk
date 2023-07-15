using DAL.Entities.Base;
using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class OrderProject : BaseEntity
    {
        public string NumberPhone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public OrderTypeEnum OrderType { get; set; }
    }
}
