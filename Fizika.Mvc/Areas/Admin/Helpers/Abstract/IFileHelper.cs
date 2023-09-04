using Fizika.Entities.DTOs;
using Fizika.Shared.Utilities.Results.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Helpers.Abstract
{
    public interface IFileHelper
    {
        Task<IDataResult<FileUploadDto>> UploadFile(string name,
            IFormFile pdfFile,string folderName = null);
        IDataResult<FileDeletedDto> FileDelete(string fileName);
    }
}
