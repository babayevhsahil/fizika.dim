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
    public class ProjectCategoryManager : IExamCategoryService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProjectCategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IDataResult<ExamCategoryDto>> Add(ExamCategoryAddDto ProjectCategoryAddDto, string createdByName)
        {
            var ProjectCategory = _mapper.Map<ExamCategory>(ProjectCategoryAddDto);
            ProjectCategory.CreatedByName = createdByName;
            ProjectCategory.ModifiedByName = createdByName;
            var addedProjectCategory=await _unitOfWork.ExamCategories.AddAsync(ProjectCategory);
            await _unitOfWork.SaveAsync();
            return new DataResult<ExamCategoryDto>(ResultStatus.Succes, Messages.ProjectCategory.Add(addedProjectCategory.Name), new ExamCategoryDto
                {
                    ExamCategory = addedProjectCategory,
                    ResultStatus=ResultStatus.Succes,
                    Message= Messages.ProjectCategory.Add(addedProjectCategory.Name)
                });
        }

        public async Task<IDataResult<ExamCategoryDto>> Delete(int ProjectCategoryId, string modifiedByName)
        {
            var ProjectCategory = await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryId);
            if (ProjectCategory != null)
            {
                ProjectCategory.IsActive = false;
                ProjectCategory.IsDeleted = true;
                ProjectCategory.ModifiedByName = modifiedByName;
                ProjectCategory.ModifiedDate = DateTime.Now;

                var deletedProjectCategory = await _unitOfWork.ExamCategories.UpdateAsync(ProjectCategory);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamCategoryDto>(ResultStatus.Succes, 
                    Messages.ProjectCategory.Delete(deletedProjectCategory.Name), new ExamCategoryDto
                    {
                        ExamCategory = deletedProjectCategory,
                        Message = Messages.ProjectCategory.Delete(deletedProjectCategory.Name),
                        ResultStatus = ResultStatus.Succes
                    });
            }
            else
            {
                return new DataResult<ExamCategoryDto>(ResultStatus.Succes, Messages.ProjectCategory.NotFound(isPlural: false), new ExamCategoryDto
                    {
                        ExamCategory = null,
                        Message = Messages.ProjectCategory.NotFound(isPlural: false),
                        ResultStatus = ResultStatus.Error
                    });
            }
        }

        public async Task<IDataResult<ExamCategoryDto>> Get(int ProjectCategoryId)
        {
            var ProjectCategory =await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryId);
            if (ProjectCategory != null)
            {
                return new DataResult<ExamCategoryDto>(ResultStatus.Succes,new ExamCategoryDto 
                {
                    ExamCategory=ProjectCategory,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamCategoryDto>(ResultStatus.Error, Messages.ProjectCategory.NotFound(isPlural:false), new ExamCategoryDto { 
                ExamCategory =null,
                ResultStatus=ResultStatus.Error,
                Message= Messages.ProjectCategory.NotFound(isPlural: false)
                });
            }
        }

        public async Task<IDataResult<ExamCategoryListDto>> GetAll()
        {
            var ProjectCategorys =await _unitOfWork.ExamCategories.GetAllAsync(null);
            if (ProjectCategorys.Count>-1)
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Succes,new ExamCategoryListDto 
                {
                ExamCategories = ProjectCategorys,
                ResultStatus=ResultStatus.Succes
                });
            }
            return new DataResult<ExamCategoryListDto>(ResultStatus.Error, Messages.ProjectCategory.NotFound(isPlural: true),
                new ExamCategoryListDto {
                    Message = Messages.ProjectCategory.NotFound(isPlural: true),
                    ExamCategories = null,
                    ResultStatus=ResultStatus.Error
                }) ;
        }

        public async Task<IDataResult<ExamCategoryListDto>> GetAllByDelete()
        {
            var ProjectCategorys = await _unitOfWork.ExamCategories.GetAllAsync(c => c.IsDeleted);
            if (ProjectCategorys.Count > -1)
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Succes, new ExamCategoryListDto
                {
                    ExamCategories = ProjectCategorys,
                    ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Error, new ExamCategoryListDto
                {
                    ExamCategories = null,
                    ResultStatus = ResultStatus.Error,
                    Message=Messages.ProjectCategory.NotFound(true)
                });
            }
        }

        public async Task<IDataResult<ExamCategoryListDto>> GetAllByNonDelete()
        {                                                                   //==false
            var ProjectCategorys = await _unitOfWork.ExamCategories.GetAllAsync(c => !c.IsDeleted);
            if (ProjectCategorys.Count > -1)
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Succes, new ExamCategoryListDto 
                {
                ExamCategories = ProjectCategorys,
                ResultStatus=ResultStatus.Succes
                });
            }
            else
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Error, Messages.ProjectCategory.NotFound(isPlural: true), new ExamCategoryListDto {
                    ExamCategories = null,
                    ResultStatus=ResultStatus.Error,
                    Message= Messages.ProjectCategory.NotFound(isPlural: true)
                });
            }
        }

        public async Task<IDataResult<ExamCategoryListDto>> GetAllByNonDeleteAndActive()
        {
            var ProjectCategorys = await _unitOfWork.ExamCategories.GetAllAsync(c => c.IsActive && !c.IsDeleted);
            if (ProjectCategorys.Count > -1)
            {
                return new DataResult<ExamCategoryListDto>(ResultStatus.Succes, new ExamCategoryListDto
                {
                    ExamCategories = ProjectCategorys,
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ExamCategoryListDto>(ResultStatus.Error, Messages.ProjectCategory.NotFound(isPlural: true), null);
        }

        public async Task<IDataResult<ExamCategoryUpdateDto>> GetUpdateDto(int ProjectCategoryId)
        {
            var result = await _unitOfWork.ExamCategories.AnyAsync(c => c.Id == ProjectCategoryId);
            if (result)
            {
                var ProjectCategory = await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryId);
                var ProjectCategoryUpdateDto = _mapper.Map<ExamCategoryUpdateDto>(ProjectCategory);
                return new DataResult<ExamCategoryUpdateDto>(ResultStatus.Succes, ProjectCategoryUpdateDto);
            }
            else
            {
                return new DataResult<ExamCategoryUpdateDto>(ResultStatus.Error, Messages.ProjectCategory.NotFound(isPlural: false), null);
            }
        }

        public async Task<IResult> HardDelete(int ProjectCategoryId)
        {
            var ProjectCategory = await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryId);
            if (ProjectCategory != null)
            {
                await _unitOfWork.ExamCategories.DeleteAsync(ProjectCategory);
                await _unitOfWork.SaveAsync();

                return new Result(ResultStatus.Succes, Messages.ProjectCategory.HardDelete(ProjectCategory.Name));
            }
            else
            {
                return new Result(ResultStatus.Error, message:
                   $"{ProjectCategory.Name} adlı kateqoriya silinə bilmədi, təkrar yoxlayın");
            }
        }

        public async Task<IDataResult<ExamCategoryDto>> UndoDelete(int ProjectCategoryId, string modifiedByName)
        {
            var ProjectCategory = await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryId);
            if (ProjectCategory != null)
            {
                ProjectCategory.IsDeleted = false;
                ProjectCategory.IsActive = true;
                ProjectCategory.ModifiedByName = modifiedByName;
                ProjectCategory.ModifiedDate = DateTime.Now;

                var deletedProjectCategory = await _unitOfWork.ExamCategories.UpdateAsync(ProjectCategory);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamCategoryDto>(ResultStatus.Succes, new ExamCategoryDto
                {
                    ExamCategory = ProjectCategory,
                    Message = Messages.ProjectCategory.UndoDelete(ProjectCategory.Name),
                    ResultStatus = ResultStatus.Succes
                });
            }
            return new DataResult<ExamCategoryDto>(ResultStatus.Error, new ExamCategoryDto
            {
                ExamCategory = null,
                Message = Messages.ProjectCategory.NotFound(false),
                ResultStatus = ResultStatus.Error
            });
        }

        public async Task<IDataResult<ExamCategoryDto>> Update(ExamCategoryUpdateDto ProjectCategoryUpdateDto, string modifiedByName)
        {
            var oldProjectCategory = await _unitOfWork.ExamCategories.GetAsync(c => c.Id == ProjectCategoryUpdateDto.Id);
            var ProjectCategory =  _mapper.Map<ExamCategoryUpdateDto,ExamCategory>(ProjectCategoryUpdateDto,oldProjectCategory);
            ProjectCategory.ModifiedByName = modifiedByName;
            if (ProjectCategory != null)
            {
                var updatedProjectCategory=await _unitOfWork.ExamCategories.UpdateAsync(ProjectCategory);
                await _unitOfWork.SaveAsync();
                return new DataResult<ExamCategoryDto>(ResultStatus.Succes, Messages.ProjectCategory.Add(updatedProjectCategory.Name), new ExamCategoryDto { 
                    ExamCategory =updatedProjectCategory,
                    Message= Messages.ProjectCategory.Add(updatedProjectCategory.Name),
                    ResultStatus=ResultStatus.Succes
                    });
            }
                return new DataResult<ExamCategoryDto>(ResultStatus.Error, message: "Xəta baş verdi", new ExamCategoryDto
                {
                    ExamCategory = null,
                    Message = "Xəta baş verdi",
                    ResultStatus = ResultStatus.Error
                });
        }
    }
}
