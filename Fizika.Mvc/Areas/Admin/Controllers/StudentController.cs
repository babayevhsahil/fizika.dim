using AutoMapper;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Extensions;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class StudentController : BaseController
    {
        private readonly IStudentsService _studentsService;
        private readonly IToastNotification _toastNotification;

        public StudentController(IStudentsService studentsService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _studentsService = studentsService ;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _studentsService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(/*"_TeamAddPartial"*/);
        }
        [HttpPost]
        public async Task<IActionResult> Add(StudentAddViewModel teamAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var teamAddDto = Mapper.Map<StudentsAddDto>(teamAddViewModel);
                var imageResult = await ImageHelper.UploadImage(teamAddViewModel.Fullname,
                    teamAddViewModel.PictureFile, PictureType.Post);
                teamAddDto.Photo = imageResult.Data.FullName;
                var result = await _studentsService.Add(teamAddDto, LoggedInUser.UserName);
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
            return View(teamAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int studentId)
        {
            var result = await _studentsService.GetUpdateDto(studentId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                var teamUpdateViewModel= Mapper.Map<StudentUpdateViewModel>(result.Data);
                return View(teamUpdateViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(StudentUpdateViewModel teamUpdateViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    var result = await _studentsService.Update(teamUpdateDto, LoggedInUser.UserName);
            //    if (result.ResultStatus == ResultStatus.Succes)
            //    {
            //        var teamUpdateAjaxModel = JsonSerializer.Serialize(new TeamUpdateAjaxViewModel
            //        {
            //            TeamDto = result.Data,
            //            TeamUpdatePartial = await this.RenderViewToStringAsync("_TeamUpdatePartial", teamUpdateDto)
            //        });
            //        return Json(teamUpdateAjaxModel);
            //    }
            //}
            //var teamUpdateErrorAjaxModel = JsonSerializer.Serialize(new TeamUpdateAjaxViewModel
            //{
            //    TeamUpdatePartial = await this.RenderViewToStringAsync("_TeamUpdatePartial", teamUpdateDto)
            //});
            //return Json(teamUpdateErrorAjaxModel);
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = teamUpdateViewModel.Photo;
                if (teamUpdateViewModel.PictureFile != null)
                {
                    var uploadedImageResult = await ImageHelper.UploadImage(teamUpdateViewModel.Fullname,
                        teamUpdateViewModel.PictureFile, PictureType.Post);
                    teamUpdateViewModel.Photo = uploadedImageResult.ResultStatus
                        == ResultStatus.Succes ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var teamUpdateDto = Mapper.Map<StudentsUpdateDto>(teamUpdateViewModel);
                var result = await _studentsService.Update(teamUpdateDto, LoggedInUser.UserName);
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
            return View(teamUpdateViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int studentId)
        {
            var result = await _studentsService.HardDelete(studentId);
            var deletedTeam = JsonSerializer.Serialize(result);
            return Json(deletedTeam);
        }
    }
}
