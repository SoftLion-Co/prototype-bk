using BLL.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.TechnologyDTO
{
    public class GetTechnologyDTO : GetBaseDTO
    {
        public string Name { get; set; } = null!;

    }
}
