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
    public class BusinessController : BaseController
    {
        private readonly IBusinessService _businessService;
        private readonly IToastNotification _toastNotification;

        public BusinessController(IBusinessService businessService, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _businessService = businessService;
            _toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _businessService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return /*PartialView("_BusinessAddPartial");*/ View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(BusinessAddViewModel businessAddViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //        var result = await _businessService.Add(businessAddDto, LoggedInUser.UserName);
            //        if (result.ResultStatus == ResultStatus.Succes)
            //        {
            //            var businessAddAjaxModel = JsonSerializer.Serialize(new BusinessAjaxViewModel
            //            {
            //                BusinessDto = result.Data,
            //                BusinessAddPartial = await this.RenderViewToStringAsync("_BusinessAddPartial", businessAddDto)
            //            });
            //            return Json(businessAddAjaxModel);
            //        }
            //}
            //var businessAddErrorAjaxModel = JsonSerializer.Serialize(new BusinessAjaxViewModel
            //{
            //    BusinessAddPartial = await this.RenderViewToStringAsync("_BusinessAddPartial", businessAddDto)
            //});
            //return Json(businessAddErrorAjaxModel);
            ///////////////////////SAGOL
            ///

            if (ModelState.IsValid)
            {
                var businessAddDto = Mapper.Map<BusinessAddDto>(businessAddViewModel);
                var imageResult = await ImageHelper.UploadImage(businessAddViewModel.Header,
                    businessAddViewModel.PictureFile, PictureType.Post);
                businessAddDto.Icon = imageResult.Data.FullName;
                var result = await _businessService.Add(businessAddDto, LoggedInUser.UserName);
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
            return View(businessAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int businessId)
        {
            var result = await _businessService.GetUpdateDto(businessId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                var businessUpdateViewModel = Mapper.Map<BusinessUpdateViewModel>(result.Data);
                return View(businessUpdateViewModel);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(BusinessUpdateViewModel businessUpdateViewModel)
        {
            if (ModelState.IsValid)
            {
                bool isNewThumbnailUploaded = false;
                var oldThumbnail = businessUpdateViewModel.Icon;
                if (businessUpdateViewModel.PictureFile != null)
                {
                    var uploadedImageResult = await ImageHelper.UploadImage(businessUpdateViewModel.Header,
                        businessUpdateViewModel.PictureFile, PictureType.Post);
                    businessUpdateViewModel.Icon = uploadedImageResult.ResultStatus
                        == ResultStatus.Succes ? uploadedImageResult.Data.FullName
                        : "postImages/defaultThumbnail.jpg";
                    if (oldThumbnail != "postImages/defaultThumbnail.jpg")
                    {
                        isNewThumbnailUploaded = true;
                    }
                }
                var businessUpdateDto = Mapper.Map<BusinessUpdateDto>(businessUpdateViewModel);
                var result = await _businessService.Update(businessUpdateDto, LoggedInUser.UserName);
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
            return View(businessUpdateViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int businessId)
        {
            var result = await _businessService.Delete(businessId, LoggedInUser.UserName);
           
            var deletedBusiness = JsonSerializer.Serialize(result.Data);
            return Json(deletedBusiness);
        }
    }
}
