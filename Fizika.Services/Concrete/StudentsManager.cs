using AutoMapper;
using Fizika.Shared.Utilities.Results.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Shared.Utilities.Results.Concrete;
using Fizika.Data.Abstract.UnitOfWorks;
using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using Fizika.Services.Abstract;
using Fizika.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Services.Concrete
{
    public class StudentsManager : IStudentsService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentsManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<StudentsDto>> Add(StudentsAddDto StudentsAddDto, string createdByName)
        {
            var Students = _mapper.Map<Students>(StudentsAddDto);
            Students.CreatedByName = createdByName;
            Students.ModifiedByName = createdByName;
            var addedStudents=await _unitOfWork.Students.AddAsync(Students);
            await _unitOfWork.SaveAsync();
            return new DataResult<StudentsDto>(ResultStatus.Succes, Messages.Students.Add(addedStudents.Fullname), new StudentsDto
                {
                    Student = addedStudents,
                    ResultStatus=ResultStatus.Succes,
                    Message = Messages.Students.Add(addedStudents.Fullname)
            });
        }
        public async Task<IDataResult<StudentsDto>> Get(int StudentsId)
        {
            var Students =await _unitOfWork.Students.GetAsync(c => c.Id == StudentsId);
            if (Students != null)
            {
                return new DataResult<StudentsDto>(ResultStatus.Succes,new StudentsDto 
                {
                    Student =Students,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<StudentsDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural:false), new StudentsDto { 
                Student=null,
                ResultStatus=ResultStatus.Error,
                Message= Messages.Students.NotFound(isPlural: false)
                });
            }
        }

        public async Task<IDataResult<StudentsListDto>> GetAll()
        {
            var Students =await _unitOfWork.Students.GetAllAsync(null);
            if (Students.Count>-1)
            {
                return new DataResult<StudentsListDto>(ResultStatus.Succes,new StudentsListDto 
                {
                Students=Students,
                ResultStatus=ResultStatus.Succes
                });
            }
            return new DataResult<StudentsListDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: true),
                new StudentsListDto {
                    Message = Messages.Students.NotFound(isPlural: true),
                    Students =null,
                    ResultStatus=ResultStatus.Error
                }) ;
        }
        public async Task<IDataResult<StudentsListDto>> GetAllByNonDeleteAndActive()
        {
            var Students = await _unitOfWork.Students.GetAllAsync(c => c.IsActive && !c.IsDeleted);
            if (Students.Count > -1)
            {
                return new DataResult<StudentsListDto>(ResultStatus.Succes, new StudentsListDto
                {
                    Students = Students,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<StudentsListDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<StudentsListDto>> GetAllBySize(int pageSize = 4, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var students =await _unitOfWork.Students.GetAllAsync(a => a.IsActive && !a.IsDeleted);
            var sortedStudents = isAscending ? students.OrderBy(a => a.Id).Take(pageSize).ToList()
                : students.OrderByDescending(a => a.Id).Take(pageSize).ToList();
            return new DataResult<StudentsListDto>(ResultStatus.Succes, new StudentsListDto
            {
                Students = sortedStudents,
                PageSize = pageSize,
                TotalCount = students.Count,
                ResultStatus = ResultStatus.Succes,
                IsAscending = false
            });
        }

        public async Task<IDataResult<StudentsUpdateDto>> GetUpdateDto(int StudentsId)
        {
            var result = await _unitOfWork.Students.AnyAsync(c => c.Id == StudentsId);
            if (result)
            {
                var Students = await _unitOfWork.Students.GetAsync(c => c.Id == StudentsId);
                var StudentsUpdateDto = _mapper.Map<StudentsUpdateDto>(Students);
                return new DataResult<StudentsUpdateDto>(ResultStatus.Succes, StudentsUpdateDto);
            }
            else
            {
                return new DataResult<StudentsUpdateDto>(ResultStatus.Error, Messages.Students.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDelete(int StudentsId)
        {
            var Students = await _unitOfWork.Students.GetAsync(c => c.Id == StudentsId);
            if (Students != null)
            {
                await _unitOfWork.Students.DeleteAsync(Students);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Succes, Messages.Students.HardDelete(Students.Fullname));
            }
            else
            {
                return new Result(ResultStatus.Error, message:
                   $"{Students.Fullname} adlı Students silinə bilmədi, təkrar yoxlayın");
            }
        }
        public async Task<IDataResult<StudentsDto>> Update(StudentsUpdateDto StudentsUpdateDto, string modifiedByName)
        {
            var oldStudents = await _unitOfWork.Students.GetAsync(c => c.Id == StudentsUpdateDto.Id);
            var Students =  _mapper.Map<StudentsUpdateDto, Students>(StudentsUpdateDto, oldStudents);
            Students.ModifiedByName = modifiedByName;
            if (Students != null)
            {
                var updatedStudents=await _unitOfWork.Students.UpdateAsync(Students);
                await _unitOfWork.SaveAsync();
                return new DataResult<StudentsDto>(ResultStatus.Succes, Messages.Students.Add(updatedStudents.Fullname), new StudentsDto { 
                    Student= updatedStudents,
                    Message= Messages.Students.Add(updatedStudents.Fullname),
                    ResultStatus=ResultStatus.Succes
                    });
            }
                return new DataResult<StudentsDto>(ResultStatus.Error, message: "Xəta baş verdi", new StudentsDto
                {
                    Student = null,
                    Message = "Xəta baş verdi",
                    ResultStatus = ResultStatus.Error
                });
        }
    }
}
