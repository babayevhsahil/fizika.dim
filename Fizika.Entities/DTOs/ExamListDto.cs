using Fizika.Entities.Concrete;
using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ExamListDto : DtoGetBase
    {
        public IList<Exam> Exams{ get; set; }
        public int? CategoryId { get; set; }
    }
}
