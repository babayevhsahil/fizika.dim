using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class ExamDetailRightSideBarViewModel
    {
        public string Header { get; set; }
        public ExamListDto ExamListDto { get; set; }
        public User User { get; set; }
        public ExamCategoryListDto ExamCategories{ get; set; }
    }
}
