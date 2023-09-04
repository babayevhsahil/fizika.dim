using AutoMapper;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.AutoMapper.Profiles
{
    public class ProjectCategoryProfile:Profile
    {
        public ProjectCategoryProfile()
        {
            CreateMap<ExamCategory, ExamCategoryAddDto>();
            CreateMap<ExamCategoryAddDto, ExamCategory>();

            CreateMap<ExamCategory, ExamCategoryUpdateDto>();
            CreateMap<ExamCategoryUpdateDto, ExamCategory>();
        }
    }
}
