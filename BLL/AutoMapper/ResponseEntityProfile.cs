using AutoMapper;
using DAL.Entities.ResponseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AutoMapper
{
    public class ResponseEntityProfile : BaseProfile
    {
        public ResponseEntityProfile() 
        {
            CreateMap(typeof(ResponseEntity<>), typeof(ResponseEntity<>));
        }
    }
}
