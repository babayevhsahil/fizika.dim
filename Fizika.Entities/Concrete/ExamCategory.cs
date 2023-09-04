using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.Concrete
{
    public class ExamCategory : EntityBase,IEntity
    {
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
}
