using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IVideoService
    {
        Task<IDataResult<VideoDto>> Get(int videoId);
        Task<IDataResult<VideoUpdateDto>> GetUpdateDto(int videoId);
        Task<IDataResult<VideoListDto>> GetAll();
        Task<IDataResult<VideoListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<VideoListDto>> GetAllByPage(int pageSize=4,int currentPage=1,bool isAscending=false);
        Task<IDataResult<VideoDto>> Add(VideoAddDto videoAddDto, string createdByName);
        Task<IDataResult<VideoDto>> Update(VideoUpdateDto videoUpdateDto, string modifiedByName);
        Task<IResult> HardDelete(int videoId);
    }
}
