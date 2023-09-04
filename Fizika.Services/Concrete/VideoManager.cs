using AutoMapper;
using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Services.Abstract;
using Fizika.Services.Utilities;
using Fizika.Shared.Utilities.Results.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Concrete
{
    public class VideoManager : IVideoService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public VideoManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<VideoDto>> Add(VideoAddDto videoAddDto, string createdByName)
        {
            var video = _mapper.Map<Video>(videoAddDto);
            video.CreatedByName = createdByName;
            video.ModifiedByName = createdByName;
            var addedvideo = await _unitOfWork.Videos.AddAsync(video);
            await _unitOfWork.SaveAsync();
            return new DataResult<VideoDto>(ResultStatus.Succes, Messages.Students.Add(addedvideo.Title), new VideoDto
            {
                Video = addedvideo,
                ResultStatus = ResultStatus.Succes,
                Message = Messages.Students.Add(addedvideo.Title)
            });
        }

        public async Task<IDataResult<VideoDto>> Get(int videoId)
        {
            var video = await _unitOfWork.Videos.GetAsync(c => c.Id == videoId);
            if (video != null)
            {
                return new DataResult<VideoDto>(ResultStatus.Succes, new VideoDto
                {
                    Video = video,
                    ResultStatus = ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<VideoDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: false), new VideoDto
                {
                    Video = null,
                    ResultStatus = ResultStatus.Error,
                    Message = Messages.Students.NotFound(isPlural: false)
                });
            }
        }

        public async Task<IDataResult<VideoListDto>> GetAll()
        {
            var videos = await _unitOfWork.Videos.GetAllAsync(null);
            if (videos.Count > -1)
            {
                return new DataResult<VideoListDto>(ResultStatus.Succes, new VideoListDto
                {
                    Videos = videos,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<VideoListDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: true),
                new VideoListDto
                {
                    Message = Messages.Students.NotFound(isPlural: true),
                    Videos = null,
                    ResultStatus = ResultStatus.Error
                });
        }

        public async Task<IDataResult<VideoListDto>> GetAllByNonDeleteAndActive()
        {
            var videos = await _unitOfWork.Videos.GetAllAsync(c => c.IsActive && !c.IsDeleted);
            if (videos.Count > -1)
            {
                return new DataResult<VideoListDto>(ResultStatus.Succes, new VideoListDto
                {
                    Videos = videos,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<VideoListDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<VideoListDto>> GetAllByPage(int pageSize = 4, int currentPage = 1, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var videos = await _unitOfWork.Videos.GetAllAsync(a => a.IsActive && !a.IsDeleted);
            var sortedVideos = isAscending ? videos.OrderBy(a => a.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : videos.OrderByDescending(a => a.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<VideoListDto>(ResultStatus.Succes, new VideoListDto
            {
                Videos = sortedVideos,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = videos.Count,
                ResultStatus = ResultStatus.Succes,
                IsAscending = false
            });
        }

        public async Task<IDataResult<VideoUpdateDto>> GetUpdateDto(int videoId)
        {
            var result = await _unitOfWork.Videos.AnyAsync(c => c.Id == videoId);
            if (result)
            {
                var videos = await _unitOfWork.Videos.GetAsync(c => c.Id == videoId);
                var VideoUpdateDto = _mapper.Map<VideoUpdateDto>(videos);
                return new DataResult<VideoUpdateDto>(ResultStatus.Succes, VideoUpdateDto);
            }
            else
            {
                return new DataResult<VideoUpdateDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDelete(int videoId)
        {
            var video = await _unitOfWork.Videos.GetAsync(c => c.Id == videoId);
            if (video != null)
            {
                await _unitOfWork.Videos.DeleteAsync(video);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Succes, Messages.Students.HardDelete(video.Title));
            }
            else
            {
                return new Result(ResultStatus.Error, message:
                   $"{video.Title} adlı video silinə bilmədi, təkrar yoxlayın");
            }
        }

        public async Task<IDataResult<VideoDto>> Update(VideoUpdateDto videoUpdateDto, string modifiedByName)
        {
            var oldVideo = await _unitOfWork.Videos.GetAsync(c => c.Id == videoUpdateDto.Id);
            var video = _mapper.Map<VideoUpdateDto, Video>(videoUpdateDto, oldVideo);
            video.ModifiedByName = modifiedByName;
            if (video != null)
            {
                var updatedVideo = await _unitOfWork.Videos.UpdateAsync(video);
                await _unitOfWork.SaveAsync();
                return new DataResult<VideoDto>(ResultStatus.Succes, Messages.Students.Add(updatedVideo.Title), new VideoDto

                {
                    Video = updatedVideo,
                    Message = Messages.Students.Add(updatedVideo.Title),
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<VideoDto>(ResultStatus.Error, message: "Xəta baş verdi", new VideoDto
            {
                Video = null,
                Message = "Xəta baş verdi",
                ResultStatus = ResultStatus.Error
            });
        }
    }
}
