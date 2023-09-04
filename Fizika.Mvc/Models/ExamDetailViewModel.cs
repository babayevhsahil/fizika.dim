using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class ExamDetailViewModel
    {
        public ExamDto ExamDto { get; set; }
        public ExamListDto ExamListDto { get; set; }
        public ExamCategoryListDto ExamCategoryListDto { get; set; }
        //public ArticleDetailRightSideBarViewModel ArticleDetailRightSideBarViewModel { get; set; }
    }
}
