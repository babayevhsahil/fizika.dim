using Fizika.Mvc.Models;
using Fizika.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.ViewComponents
{
    public class ExamSidebarViewComponent:ViewComponent
    {
        private readonly IExamCategoryService _examCategoryService;
        private readonly IExamService _examService;
        public ExamSidebarViewComponent(IExamCategoryService examCategoryService, IExamService examService)
        {
            _examCategoryService = examCategoryService;
            _examService = examService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoriesResult = await _examCategoryService.GetAllByNonDeleteAndActive();
            var examResult = await _examService.GetAllByPaging(null,1,3,false);
            return View(new ExamSidebarViewModel
            {
                Exams= examResult.Data.Exams,
                ExamCategories = categoriesResult.Data.ExamCategories
            });
        }
    }
}
