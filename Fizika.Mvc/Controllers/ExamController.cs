using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Mvc.Models;
using Fizika.Services.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Controllers
{
    public class ExamController : Controller
    {
        private readonly IExamService _examService;
        private readonly IExamCategoryService _examcategoryService;
        private IHostingEnvironment _environment;
        private IUnitOfWork _unitOfWork;
        public ExamController(IExamService ExamService, IExamCategoryService categoryService
            ,IHostingEnvironment environment, IUnitOfWork unitOfWork)
        {
            _examService = ExamService;
            _examcategoryService = categoryService;
            _environment = environment;
            _unitOfWork = unitOfWork;
        }
        [Route("Sinaq")]
        [HttpGet]
        public async Task<IActionResult> Index(int? categoryId, int currentPage = 1, int pageSize = 6, bool isAscending = false)
        {
            var ExamResult = await (categoryId == null
                ? _examService.GetAllByPaging(null, currentPage, pageSize, isAscending)
                : _examService.GetAllByPaging(categoryId, currentPage, pageSize, isAscending));
            return View(ExamResult.Data);
        }
        //[HttpGet]
        //public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 5, bool isAscending = false)
        //{
        //    var searchResult = await _examService.SearchAsync(keyword, currentPage, pageSize, isAscending);
        //    if (searchResult.ResultStatus == ResultStatus.Succes)
        //    {
        //        return View(new ExamSearchViewModel
        //        {
        //            ExamListDto = searchResult.Data,
        //            Keyword = keyword
        //        });
        //    }
        //    return NotFound();
        //}
        [HttpGet]
        public async Task<IActionResult> Detail(int ExamId)
        {
            var ExamResult = await _examService.Get(ExamId);
            var exams = await _examService.GetAllByPaging(ExamResult.Data.Exam.ExamCategoryId, 1, 3, false);
            var categories = await _examcategoryService.GetAllByNonDeleteAndActive();
            if (ExamResult.ResultStatus == ResultStatus.Succes)
            {
                //await _examService.IncreaseViewCount(ExamId);
                return View(new ExamDetailViewModel
                {
                    ExamDto = ExamResult.Data,
                    ExamCategoryListDto = categories.Data,
                    ExamListDto = exams.Data

                });
            }
            return NotFound();
        }
        [Obsolete]
        public async Task<IActionResult> DownloadFile(string filePath,int id)
        {
            //var result = await _examService.Get(id);
            string path = Path.Combine(this._environment.WebRootPath, "files/") + filePath;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            await _examService.IncreaseDownloadCount(id);
            return File(bytes, "application/octet-stream", filePath);
        }
    }
}
