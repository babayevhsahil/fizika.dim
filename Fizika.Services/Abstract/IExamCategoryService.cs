using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IExamCategoryService
    {
        Task<IDataResult<ExamCategoryDto>> Get(int projectCategoryId);
        Task<IDataResult<ExamCategoryUpdateDto>> GetUpdateDto(int projectCategoryId);
        Task<IDataResult<ExamCategoryListDto>> GetAll();
        Task<IDataResult<ExamCategoryListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ExamCategoryDto>> Add(ExamCategoryAddDto projectCategoryAddDto, string createdByName);
        Task<IDataResult<ExamCategoryDto>> Update(ExamCategoryUpdateDto projectCategoryUpdateDto, string modifiedByName);
        Task<IResult> HardDelete(int projectCategoryId);
    }
}
