using Fizika.Data.Abstract;
using Fizika.Entities.Concrete;
using Fizika.Shared.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Concrete.EntityFramework.Repositories
{
    public class ExamRepository : EfEntityRepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(DbContext Context) : base(Context)
        {
        }
    }
}
