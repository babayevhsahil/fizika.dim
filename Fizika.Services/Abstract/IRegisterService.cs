using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Abstract
{
    public interface IRegisterService
    {
        Task<IDataResult<RegisterListDto>> GetAll();
        Task<IDataResult<RegisterDto>> Get(int registerId);
        Task<IDataResult<RegisterDto>> Add(RegisterAddDto registerAddDto, string createdByName);
        Task<IResult> HardDelete(int registerId);
    }
}
