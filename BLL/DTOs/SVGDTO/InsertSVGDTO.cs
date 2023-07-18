using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.SVG
{
    public class InsertSVGDTO
    {
        public byte[] Content { get; set; } = null!;
        public Guid BlogId { get; set; }
    }
}
