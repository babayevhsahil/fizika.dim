using AutoMapper;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExamCategoryController : BaseController
    {
        private readonly IExamCategoryService _ExamCategoryService;

        public ExamCategoryController(IExamCategoryService ExamCategoryService, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _ExamCategoryService = ExamCategoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _ExamCategoryService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_ExamCategoryAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamCategoryAddDto ProjectCategoryAddDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _ExamCategoryService.Add(ProjectCategoryAddDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    var ProjectCategoryAddAjaxModel = JsonSerializer.Serialize(new ExamCategoryAjaxViewModel
                    {
                        ExamCategoryDto = result.Data,
                        ExamCategoryPartial = await this.RenderViewToStringAsync("_ExamCategoryAddPartial", ProjectCategoryAddDto)
                    });
                    return Json(ProjectCategoryAddAjaxModel);
                }
            }
            var projectAddErrorAjaxModel = JsonSerializer.Serialize(new ExamCategoryAjaxViewModel
            {
                ExamCategoryPartial = await this.RenderViewToStringAsync("_ExamCategoryAddPartial", ProjectCategoryAddDto)
            });
            return Json(projectAddErrorAjaxModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int ExamCategoryId)
        {
            var result = await _ExamCategoryService.GetUpdateDto(ExamCategoryId);
            if (result.ResultStatus == ResultStatus.Succes)
            {
                return PartialView("_ProjectCategoryUpdatePartial", result.Data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Update(ExamCategoryUpdateDto ProjectCategoryUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _ExamCategoryService.Update(ProjectCategoryUpdateDto, LoggedInUser.UserName);
                if (result.ResultStatus == ResultStatus.Succes)
                {
                    var ProjectCategoryUpdateAjaxModel = JsonSerializer.Serialize(new ExamCategoryUpdateAjaxViewModel
                    {
                        ExamCategoryDto = result.Data,
                        ExamCategoryUpdatePartial = await this.RenderViewToStringAsync("_ProjectCategoryUpdatePartial", ProjectCategoryUpdateDto)
                    });
                    return Json(ProjectCategoryUpdateAjaxModel);
                }
            }
            var ProjectCategoryUpdateErrorAjaxModel = JsonSerializer.Serialize(new ExamCategoryUpdateAjaxViewModel
            {
                ExamCategoryUpdatePartial = await this.RenderViewToStringAsync("_ProjectCategoryUpdatePartial", ProjectCategoryUpdateDto)
            });
            return Json(ProjectCategoryUpdateErrorAjaxModel);
        }
        [HttpPost]
        public async Task<JsonResult> Delete(int examCategoryId)
        {
            var result = await _ExamCategoryService.HardDelete(examCategoryId);
            var deletedProjectCategory = JsonSerializer.Serialize(result);
            return Json(deletedProjectCategory);
        }
    }
}
