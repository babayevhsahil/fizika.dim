using Fizika.Entities.Concrete;
using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ExamCategoryListDto:DtoGetBase
    {
        public IList<ExamCategory> ExamCategories{ get; set; }
    }
}
