using BLL.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.RatingDTO
{
    public class UpdateRatingDTO : UpdateBaseDTO
    {
        public double Mark { get; set; }
        public Guid ProjectId { get; set; }
    }
}
