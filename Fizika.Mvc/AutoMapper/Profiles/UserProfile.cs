using AutoMapper;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile(/*IImageHelper imageHelper*/)
        {
            CreateMap<UserAddDto, User>();
            //    .ForMember(dest=>dest.Picture,opt=>opt
            //.MapFrom(x=>imageHelper.UploadImage(x.UserName,x.PictureFile,PictureType.User,null)));  
            CreateMap<User,UserAddDto>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();
        }
    }
}
