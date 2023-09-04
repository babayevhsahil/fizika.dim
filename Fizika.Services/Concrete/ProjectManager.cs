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
    public class ProjectManager : IExamService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ExamDto>> Add(ExamAddDto ProjectAddDto, string createdByName)
        {
                var Project = _mapper.Map<Exam>(ProjectAddDto);
                Project.CreatedByName = createdByName;
                Project.ModifiedByName = createdByName;
                var addedProject = await _unitOfWork.Exams.AddAsync(Project);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamDto>(ResultStatus.Succes, Messages.Project.Add(addedProject.ExamName), new ExamDto
                {
                    Exam = addedProject,
                    ResultStatus = ResultStatus.Succes,
                    Message = Messages.Project.Add(addedProject.ExamName)
                });
        }

        public async Task<IDataResult<int>> Count()
        {
            var ExamsCount = await _unitOfWork.Exams.CountAsync(c=>c.IsActive);
            if (ExamsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, ExamsCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Xəta baş verdi", -1);
        }

        public async Task<IDataResult<int>> CountByNonDeleted()
        {
            var ExamsCount = await _unitOfWork.Exams.CountAsync(c => !c.IsDeleted);
            if (ExamsCount > -1)
            {
                return new DataResult<int>(ResultStatus.Succes, ExamsCount);
            }
            return new DataResult<int>(ResultStatus.Error, "Xəta baş verdi", -1);
        }

        public async Task<IDataResult<ExamDto>> Delete(int ProjectId, string modifiedByName)
        {
            var Project = await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectId);
            if (Project != null)
            {
                Project.IsActive = false;
                Project.IsDeleted = true;
                Project.ModifiedByName = modifiedByName;
                Project.ModifiedDate = DateTime.Now;

                var deletedProject = await _unitOfWork.Exams.UpdateAsync(Project);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamDto>(ResultStatus.Succes, 
                    Messages.Project.Delete(deletedProject.ExamName), new ExamDto
                    {
                        Exam = deletedProject,
                        Message = Messages.Project.Delete(deletedProject.ExamName),
                        ResultStatus = ResultStatus.Succes
                    });
            }
            else
            {
                return new DataResult<ExamDto>(ResultStatus.Succes, Messages.Project.NotFound(isPlural: false), new ExamDto
                    {
                        Exam = null,
                        Message = Messages.Project.NotFound(isPlural: false),
                        ResultStatus = ResultStatus.Error
                    });
            }
        }

        public async Task<IDataResult<ExamDto>> Get(int ProjectId)
        {
            var Project =await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectId,c=>c.Examcategory);
            if (Project != null)
            {
                return new DataResult<ExamDto>(ResultStatus.Succes,new ExamDto 
                {
                    Exam=Project,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamDto>(ResultStatus.Error, Messages.Project.NotFound(isPlural:false), new ExamDto { 
                Exam=null,
                ResultStatus=ResultStatus.Error,
                Message= Messages.Project.NotFound(isPlural: false)
                });
            }
        }

        public async Task<IDataResult<ExamListDto>> GetAll()
        {
            var Exams =await _unitOfWork.Exams.GetAllAsync(null);
            if (Exams.Count>-1)
            {
                return new DataResult<ExamListDto>(ResultStatus.Succes,new ExamListDto 
                {
                Exams=Exams,
                ResultStatus=ResultStatus.Succes
                });
            }
            return new DataResult<ExamListDto>(ResultStatus.Error, Messages.Project.NotFound(isPlural: true),
                new ExamListDto {
                    Message = Messages.Project.NotFound(isPlural: true),
                    Exams=null,
                    ResultStatus=ResultStatus.Error
                }) ;
        }

        public async Task<IDataResult<ExamListDto>> GetAllByDelete()
        {
            var Exams = await _unitOfWork.Exams.GetAllAsync(c => c.IsDeleted);
            if (Exams.Count > -1)
            {
                return new DataResult<ExamListDto>(ResultStatus.Succes, new ExamListDto
                {
                    Exams = Exams,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamListDto>(ResultStatus.Error, new ExamListDto
                {
                    Exams = null,
                    ResultStatus = ResultStatus.Error,
                    Message=Messages.Project.NotFound(true)
                });
            }
        }

        public async Task<IDataResult<ExamListDto>> GetAllByNonDelete()
        {                                                                   //==false
            var Exams = await _unitOfWork.Exams.GetAllAsync(c => !c.IsDeleted);
            if (Exams.Count > -1)
            {
                return new DataResult<ExamListDto>(ResultStatus.Succes, new ExamListDto 
                { 
                Exams=Exams,
                ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamListDto>(ResultStatus.Error, Messages.Project.NotFound(isPlural: true), new ExamListDto { 
                    Exams=null,
                    ResultStatus=ResultStatus.Error,
                    Message= Messages.Project.NotFound(isPlural: true)
                });
            }
        }

        public async Task<IDataResult<ExamListDto>> GetAllByNonDeleteAndActive()
        {
            var Exams = await _unitOfWork.Exams.GetAllAsync(c => c.IsActive && !c.IsDeleted,c=>c.Examcategory);
            if (Exams.Count > -1)
            {
                return new DataResult<ExamListDto>(ResultStatus.Succes, new ExamListDto
                {
                    Exams = Exams,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ExamListDto>(ResultStatus.Error, Messages.Project.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ExamUpdateDto>> GetUpdateDto(int ProjectId)
        {
            var result = await _unitOfWork.Exams.AnyAsync(c => c.Id == ProjectId);
            if (result)
            {
                var Project = await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectId);
                var ProjectUpdateDto = _mapper.Map<ExamUpdateDto>(Project);
                return new DataResult<ExamUpdateDto>(ResultStatus.Succes, ProjectUpdateDto);
            }
            else
            {
                return new DataResult<ExamUpdateDto>(ResultStatus.Error, Messages.Project.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDelete(int ProjectId)
        {
            var Project = await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectId);
            if (Project != null)
            {
                await _unitOfWork.Exams.DeleteAsync(Project);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Succes, Messages.Project.HardDelete(Project.ExamName));
            }
            else
            {
                return new Result(ResultStatus.Error, message:
                   $"{Project.ExamName} adlı kateqoriya silinə bilmədi, təkrar yoxlayın");
            }
        }

        public async Task<IDataResult<ExamDto>> UndoDelete(int ProjectId, string modifiedByName)
        {
            var Project = await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectId);
            if (Project != null)
            {
                Project.IsDeleted = false;
                Project.IsActive = true;
                Project.ModifiedByName = modifiedByName;
                Project.ModifiedDate = DateTime.Now;

                var deletedProject = await _unitOfWork.Exams.UpdateAsync(Project);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamDto>(ResultStatus.Succes, new ExamDto
                {
                    Exam = Project,
                    Message = Messages.Project.UndoDelete(Project.ExamName),
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ExamDto>(ResultStatus.Error, new ExamDto
            {
                Exam = null,
                Message = Messages.Project.NotFound(false),
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IDataResult<ExamDto>> Update(ExamUpdateDto ProjectUpdateDto, string modifiedByName)
        {
            var oldProject = await _unitOfWork.Exams.GetAsync(c => c.Id == ProjectUpdateDto.Id);
            var Project =  _mapper.Map<ExamUpdateDto,Exam>(ProjectUpdateDto,oldProject);
            Project.ModifiedByName = modifiedByName;
            if (Project != null)
            {
                var updatedProject=await _unitOfWork.Exams.UpdateAsync(Project);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamDto>(ResultStatus.Succes, Messages.Project.Add(updatedProject.ExamName), new ExamDto { 
                    Exam=updatedProject,
                    Message= Messages.Project.Add(updatedProject.ExamName),
                    ResultStatus=ResultStatus.Succes
                    });
            }
                return new DataResult<ExamDto>(ResultStatus.Error, message: "Xəta baş verdi", new ExamDto
                {
                    Exam = null,
                    Message = "Xəta baş verdi",
                    ResultStatus = ResultStatus.Error
                });
        }
        public async Task<IDataResult<ExamListDto>> GetAllByPaging(int? categoryId, int currentPage = 1,
           int pageSize = 1, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var Exams = categoryId == null
                ? await _unitOfWork.Exams.GetAllAsync(a => a.IsActive && !a.IsDeleted, a => a.Examcategory)
                : await _unitOfWork.Exams.GetAllAsync(a => a.IsActive && !a.IsDeleted && a.ExamCategoryId == categoryId, a => a.Examcategory);
            var sortedExams = isAscending ? Exams.OrderBy(a => a.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : Exams.OrderByDescending(a => a.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new DataResult<ExamListDto>(ResultStatus.Succes, new ExamListDto
            {
                Exams = sortedExams,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = Exams.Count,
                ResultStatus = ResultStatus.Succes,
                IsAscending = false
            });
        }

        public async Task<IResult> IncreaseDownloadCount(int examId)
        {
            var exam = await _unitOfWork.Exams.GetAsync(a => a.Id == examId);
            if (exam != null)
            {
                exam.DownloadCount += 1;
                await _unitOfWork.Exams.UpdateAsync(exam);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Succes, Messages.Article.IncreaseViewCount(exam.ExamName));
            }
            return new Result(ResultStatus.Error, Messages.Article.NotFound(false));
        }
    }
}
