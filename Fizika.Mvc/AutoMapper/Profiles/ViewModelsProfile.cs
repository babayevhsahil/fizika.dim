using AutoMapper;
using Fizika.Entities.Concrete;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fizika.Mvc.Models;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Entities.ComplexTypes;

namespace Fizika.Mvc.AutoMapper.Profiles
{
    public class ViewModelsProfile : Profile
    {
        public ViewModelsProfile(/*IImageHelper imageHelper*/)
        {
            CreateMap<StudentAddViewModel, StudentsAddDto>();
            CreateMap<StudentsAddDto, StudentAddViewModel>();

            CreateMap<StudentUpdateViewModel, StudentsUpdateDto>();
            CreateMap<StudentsUpdateDto, StudentUpdateViewModel>();

            CreateMap<VideoAddViewModel, VideoAddDto>();
            CreateMap<VideoAddDto, VideoAddViewModel>();

            CreateMap<VideoUpdateViewModel, VideoUpdateDto>();
            CreateMap<VideoUpdateDto, VideoUpdateViewModel>();

            CreateMap<ExamAddViewModel, ExamAddDto>();
            CreateMap<BusinessAddViewModel, BusinessAddDto>();
            CreateMap<BusinessUpdateDto, BusinessUpdateViewModel>();
            CreateMap<BusinessUpdateViewModel, BusinessUpdateDto>();
            CreateMap<ArticleAddViewModel, ArticleAddDto>();
            // ForMember(dest => dest.Thumbnail, opt => opt
            //.MapFrom(x => imageHelper.UploadImage(x.Title, x.ThumbnailFile, PictureType.Post, null)));
            CreateMap<ArticleUpdateViewModel, ArticleUpdateDto>();
            CreateMap<ArticleUpdateDto, ArticleUpdateViewModel>();

            CreateMap<ArticleRightSideBarWidgetOptions, ArticleRightSideBarWidgetOptionsViewModel>();
        }
    }
}
