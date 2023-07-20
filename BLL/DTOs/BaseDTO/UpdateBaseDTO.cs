using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.Base
{
    public class UpdateBaseDTO
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
