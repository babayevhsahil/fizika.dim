using AutoMapper;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using Fizika.Mvc.Areas.Admin.Helpers.Concrete;
using Fizika.Mvc.Areas.Admin.Models;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ExamController : BaseController
    {
        private readonly IExamService _examService;
        private readonly IExamCategoryService _examCategoryService;
        private readonly IToastNotification _toastNotification;
        private readonly IFileHelper _fileHelper;
        [Obsolete]
        private IHostingEnvironment _environment;

        [Obsolete]
        public ExamController(IExamService examService, IHostingEnvironment environment, IExamCategoryService examCategoryService, IFileHelper fileHelper, IToastNotification toastNotification, UserManager<User> userManager, IMapper mapper, IImageHelper imageHelper) : base(userManager, mapper, imageHelper)
        {
            _examService = examService;
            _examCategoryService = examCategoryService;
            _toastNotification = toastNotification;
            _fileHelper = fileHelper;
            _environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _examService.GetAllByNonDeleteAndActive();
            return View(result.Data);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var result = await _examCategoryService.GetAllByNonDeleteAndActive();
            if (result.ResultStatus == ResultStatus.Succes)
            {
                return View(new ExamAddViewModel
                {
                    ExamCategories = result.Data.ExamCategories
                });
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ExamAddViewModel examAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var examAddDto = Mapper.Map<ExamAddDto>(examAddViewModel);
                //Pdf Upload
                var pdfResult = await _fileHelper.UploadFile(examAddViewModel.ExamName,
                    examAddViewModel.Link);
                examAddDto.Link = pdfResult.Data.FullName;
                var result = await _examService.Add(examAddDto, LoggedInUser.UserName);
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
            var examcategories = await _examCategoryService.GetAllByNonDeleteAndActive();
            examAddViewModel.ExamCategories = examcategories.Data.ExamCategories;
            return View(examAddViewModel);
        }
        [HttpPost]
        public async Task<JsonResult> HardDelete(int examId)
        {
            var deletedExam = await _examService.Get(examId);
            var deletedFile = deletedExam.Data.Exam.Link;
            _fileHelper.FileDelete(deletedFile);
            var result = await _examService.HardDelete(examId);
            var hardDeletedExamResult = JsonSerializer.Serialize(result);
            return Json(hardDeletedExamResult);
        }

        [Obsolete]
        public IActionResult DownloadFile(string filePath)
        {
                string path = Path.Combine(this._environment.WebRootPath, "files/") + filePath;
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                return File(bytes, "application/octet-stream", filePath);
        }
        
    }
}
