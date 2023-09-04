using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class ExamCategoryAjaxViewModel
    {
        public ExamCategoryDto ExamCategoryDto { get; set; }
        public string ExamCategoryPartial { get; set; }
        public ExamCategoryAddDto ExamCategoryAddDto { get; set; }

    }
}
