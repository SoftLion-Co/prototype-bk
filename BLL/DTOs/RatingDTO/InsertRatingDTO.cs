using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs.RatingDTO
{
    public class InsertRatingDTO 
    {
        public double Mark { get; set; }
        public Guid ProjectId { get; set; }
    }
}
