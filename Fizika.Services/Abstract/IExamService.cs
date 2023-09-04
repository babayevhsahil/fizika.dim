using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IExamService
    {
        Task<IDataResult<ExamDto>> Get(int projectId);
        Task<IDataResult<ExamUpdateDto>> GetUpdateDto(int projectId);
        Task<IDataResult<ExamListDto>> GetAll();
        Task<IDataResult<ExamListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<ExamListDto>> GetAllByPaging(int? categoryId,
         int currentPage = 1, int pageSize = 1, bool isAscending = false);
        Task<IResult> IncreaseDownloadCount(int examId);
        Task<IDataResult<ExamDto>> Add(ExamAddDto projectAddDto, string createdByName);
        Task<IDataResult<ExamDto>> Update(ExamUpdateDto projectUpdateDto, string modifiedByName);
        Task<IResult> HardDelete(int projectId);
    }
}
