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
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<Exam, ExamAddDto>();
            CreateMap<ExamAddDto, Exam>();

            CreateMap<Exam, ExamUpdateDto>();
            CreateMap<ExamUpdateDto, Exam>();
        }
    }
}
