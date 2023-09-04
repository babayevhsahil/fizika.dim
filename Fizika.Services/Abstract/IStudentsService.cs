using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IStudentsService
    {
        Task<IDataResult<StudentsDto>> Get(int StudentsId);
        Task<IDataResult<StudentsUpdateDto>> GetUpdateDto(int StudentsId);
        Task<IDataResult<StudentsListDto>> GetAllBySize(int pageSize = 4, bool isAscending = false);
        Task<IDataResult<StudentsListDto>> GetAll();
        Task<IDataResult<StudentsListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<StudentsDto>> Add(StudentsAddDto StudentsAddDto, string createdByName);
        Task<IDataResult<StudentsDto>> Update(StudentsUpdateDto StudentsUpdateDto, string modifiedByName);
        Task<IResult> HardDelete(int StudentsId);
    }
}
