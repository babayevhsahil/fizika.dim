using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IBusinessService
    {
        Task<IDataResult<BusinessDto>> Get(int businessId);
        Task<IDataResult<BusinessUpdateDto>> GetUpdateDto(int businessId);
        Task<IDataResult<BusinessListDto>> GetAll();
        Task<IDataResult<BusinessListDto>> GetAllByNonDelete();
        Task<IDataResult<BusinessListDto>> GetAllByNonDeleteAndActive();
        Task<IDataResult<BusinessListDto>> GetAllByDelete();
        Task<IDataResult<BusinessDto>> Add(BusinessAddDto businessAddDto, string createdByName);
        Task<IDataResult<BusinessDto>> Update(BusinessUpdateDto businessUpdateDto, string modifiedByName);
        Task<IDataResult<BusinessDto>> Delete(int businessId, string modifiedByName);
        Task<IDataResult<BusinessDto>> UndoDelete(int businessId, string modifiedByName);
        Task<IResult> HardDelete(int businessId);
    }
}
