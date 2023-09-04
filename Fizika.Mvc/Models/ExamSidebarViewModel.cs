using Fizika.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class ExamSidebarViewModel
    {
        public IList<ExamCategory> ExamCategories { get; set; }
        public IList<Exam> Exams { get; set; }
    }
}
