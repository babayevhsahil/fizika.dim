using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class Exam:EntityBase,IEntity
    {
        public string ExamName { get; set; }
        public string Teacher { get; set; }
        public string ExamYear { get; set; }
        public string FileName { get; set; }
        public string Link { get; set; }
        public int DownloadCount { get; set; }
        public int ExamCategoryId { get; set; }
        public ExamCategory Examcategory { get; set; }
    }
}
