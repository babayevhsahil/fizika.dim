using AutoMapper;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class VideoController : BaseController
    {
        private readonly IVideoService _videoService;
        private readonly IToastNotification _toastNotification;

        public VideoController(IVideoService videoService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _videoService = videoService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _videoService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(/*"_TeamAddPartial"*/);
        }
        [HttpPost]
        public async Task<IActionResult> Add(VideoAddViewModel videoAddViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var videoAddDto = Mapper.Map<VideoAddDto>(videoAddViewModel);
                    var imageResult = await ImageHelper.UploadImage(videoAddViewModel.Title,
                        videoAddViewModel.PictureFile, PictureType.Post);
                    videoAddDto.Thumbnail = imageResult.Data.FullName;
                    var result = await _videoService.Add(videoAddDto, LoggedInUser.UserName);
                    if (result.ResultStatus == ResultStatus.Succes)
                    {
                        _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                        {
                            Title = "Uğurlu əməliyyat"
                        });
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", result.Message);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return View(videoAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int videoId)
        {
            var result = await _videoService.GetUpdateDto(videoId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                var videoUpdateViewModel = Mapper.Map<VideoUpdateViewModel>(result.Data);
                return View(videoUpdateViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(VideoUpdateViewModel videoUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = videoUpdateViewModel.Thumbnail;
                if (videoUpdateViewModel.PictureFile != null)
                {
                    var uploadedImageResult = await ImageHelper.UploadImage(videoUpdateViewModel.Title,
                        videoUpdateViewModel.PictureFile, PictureType.Post);
                    videoUpdateViewModel.Thumbnail = uploadedImageResult.ResultStatus
                        == ResultStatus.Succes ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var videoUpdateDto = Mapper.Map<VideoUpdateDto>(videoUpdateViewModel);
                var result = await _videoService.Update(videoUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    if (isNewThumbnailUploaded)
                    {
                        ImageHelper.ImageDelete(oldThumbnail);
                    }
                    _toastNotification.AddSuccessToastMessage(result.Message, new ToastrOptions
                    {
                        Title = "Uğurlu əməliyyat",
                        CloseButton = true
                    });
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }
            return View(videoUpdateViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int videoId)
        {
            var result = await _videoService.HardDelete(videoId);
            var deletedVideo = JsonSerializer.Serialize(result);
            return Json(deletedVideo);
        }
    }
}
