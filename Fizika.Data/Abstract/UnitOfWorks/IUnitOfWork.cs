using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Abstract.UnitOfWorks
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IArticleRepository Articles { get; }
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }  //_unitOfWork.Categories.AddAsync()
        IExamRepository Exams { get; }
        IExamCategoryRepository ExamCategories { get; }
        IBusinessRepository Business { get; }
        IStudentsRepository Students { get; }
        IRegisterRepository Registers { get; }
        IVideoRepository Videos { get;}
        Task<int> SaveAsync();
    }
}
