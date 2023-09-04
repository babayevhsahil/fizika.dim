using AutoMapper;
using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Services.Abstract;
using Fizika.Services.Utilities;
using Fizika.Shared.Utilities.Results.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Concrete
{
    public class RegisterManager : IRegisterService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RegisterManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<RegisterDto>> Add(RegisterAddDto RegisterAddDto, string createdByName)
        {
            var register = _mapper.Map<Register>(RegisterAddDto);
            register.CreatedByName = createdByName;
            register.ModifiedByName = createdByName;
            var addedRegister = await _unitOfWork.Registers.AddAsync(register);
            await _unitOfWork.SaveAsync();
            return new DataResult<RegisterDto>(ResultStatus.Succes, Messages.Students.Add(addedRegister.Fullname), new RegisterDto
            {
                Register = addedRegister,
                ResultStatus = ResultStatus.Succes,
                Message = Messages.Students.Add(addedRegister.Fullname)
            });
        }
        public async Task<IDataResult<RegisterDto>> Get(int registerId)
        {
            var register = await _unitOfWork.Registers.GetAsync(c => c.Id == registerId);
            if (register != null)
            {
                return new DataResult<RegisterDto>(ResultStatus.Succes, new RegisterDto
                {
                    Register = register,
                    ResultStatus = ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<RegisterDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: false), new RegisterDto
                {
                    Register = null,
                    ResultStatus = ResultStatus.Error,
                    Message = Messages.Students.NotFound(isPlural: false)
                });
            }
        }

        public async Task<IDataResult<RegisterListDto>> GetAll()
        {
            var registers = await _unitOfWork.Registers.GetAllAsync(null);
            if (registers.Count > -1)
            {
                return new DataResult<RegisterListDto>(ResultStatus.Succes, new RegisterListDto
                {
                    Registers = registers,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<RegisterListDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: true),
                new RegisterListDto
                {
                    Message = Messages.Students.NotFound(isPlural: true),
                    Registers = null,
                    ResultStatus = ResultStatus.Error
                });
        }

        public async Task<IResult> HardDelete(int registerId)
        {
            var register = await _unitOfWork.Registers.GetAsync(c => c.Id == registerId);
            if (register != null)
            {
                await _unitOfWork.Registers.DeleteAsync(register);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Succes, Messages.Students.HardDelete(register.Fullname));
            }
            else
            {
                return new Result(ResultStatus.Error, message:
                   $"{register.Fullname} adlı Students silinə bilmədi, təkrar yoxlayın");
            }
        }
    }
}
