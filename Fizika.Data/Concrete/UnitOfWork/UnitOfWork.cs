using Fizika.Data.Abstract;
using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Data.Concrete.EntityFramework.Context;
using Fizika.Data.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Data.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FizikaContext _context;
        private  ArticleRepository _articleRepository;
        private  CommentRepository _commentRepository;
        private  CategoryRepository _categoryRepository;
        private  ExamRepository _examRepository;
        private  ExamCategoryRepository _examCategoryRepository;
        private  BusinessRepository _businessRepository;
        private  StudentsRepository _StudentsRepository;
        private RegisterRepository _RegisterRepository;
        private VideoRepository _videoRepository;
        public UnitOfWork(FizikaContext context)
        {
            _context = context;
        }
        public IArticleRepository Articles => _articleRepository ??= new ArticleRepository(_context);

        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);

        public ICommentRepository Comments => _commentRepository ??= new CommentRepository(_context);

        public IExamRepository Exams => _examRepository ??= new ExamRepository(_context);

        public IExamCategoryRepository ExamCategories => _examCategoryRepository ??= new ExamCategoryRepository(_context);

        public IBusinessRepository Business => _businessRepository ??= new BusinessRepository(_context);

        public IStudentsRepository Students => _StudentsRepository ??= new StudentsRepository(_context);
        public IRegisterRepository Registers => _RegisterRepository ??= new RegisterRepository(_context);

        public IVideoRepository Videos => _videoRepository ??= new VideoRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveAsync()
        {
           return await  _context.SaveChangesAsync();
        }
    }
}
