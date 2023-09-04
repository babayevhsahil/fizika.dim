using AutoMapper;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fizika.Mvc.AutoMapper.Profiles
{
    public class TeamProfile : Profile
    {
        public TeamProfile()
        {
            CreateMap<StudentsAddDto, Students>();
            // ForMember(dest => dest.Photo, opt => opt
            //.MapFrom(x => imageHelper.UploadImage(x.Fullname, x.PictureFile, PictureType.User, null)));
            CreateMap<Students, StudentsAddDto>();

            CreateMap<Students, StudentsUpdateDto>();
            CreateMap<StudentsUpdateDto, Students>();
        }
    }
}
