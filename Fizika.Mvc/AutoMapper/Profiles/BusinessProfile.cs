using AutoMapper;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Mvc.AutoMapper.Profiles
{
    public class BusinessProfile:Profile
    {
        public BusinessProfile()
        {
            CreateMap<Business, BusinessAddDto>();
            CreateMap<BusinessAddDto, Business>();

            CreateMap<Business, BusinessUpdateDto>();
            CreateMap<BusinessUpdateDto, Business>();
        }
    }
}
