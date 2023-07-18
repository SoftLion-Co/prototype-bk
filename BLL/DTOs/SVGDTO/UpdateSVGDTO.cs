using BLL.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.SVGDTO
{
    public class UpdateSVGDTO : UpdateBaseDTO
    {
        public byte[] Content { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
