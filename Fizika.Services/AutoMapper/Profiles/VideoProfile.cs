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
    public class VideoProfile:Profile
    {
        public VideoProfile()
        {
            CreateMap<Video, VideoAddDto>();
            CreateMap<VideoAddDto, Video>();

            CreateMap<Video, VideoUpdateDto>();
            CreateMap<VideoUpdateDto, Video>();
        }
        
    }
}
