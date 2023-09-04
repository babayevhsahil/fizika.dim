using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class ExamCategoryUpdateAjaxViewModel
    {
        public ExamCategoryUpdateDto ExamCategoryUpdateDto { get; set; }
        public ExamCategoryDto ExamCategoryDto { get; set; }
        public string ExamCategoryUpdatePartial { get; set; }
    }
}
