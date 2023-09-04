using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Fizika.Shared.Utilities.Extensions;
using Fizika.Shared.Utilities.Results.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Shared.Utilities.Results.Concrete;
using Fizika.Entities.ComplexTypes;
using Fizika.Entities.DTOs;
using Fizika.Mvc.Areas.Admin.Helpers.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _wwwroot;
        private readonly string imgFolder = "img";
        private const string userImagesFolder = "userImages";
        private const string postImagesFolder = "postImages";
        public ImageHelper(IWebHostEnvironment env)
        {
            _env = env;
            _wwwroot = _env.WebRootPath;
        }

        public IDataResult<ImageDeletedDto> ImageDelete(string PictureName)
        {

            var fileToDelete = Path.Combine($"{_wwwroot}/{imgFolder}", PictureName);
            if (System.IO.File.Exists(fileToDelete))
            {
                var fileInfo = new FileInfo(fileToDelete);
                var imageDeletedDto = new ImageDeletedDto
                {
                    FullName = PictureName,
                    Extension = fileInfo.Extension,
                    Path = fileInfo.FullName,
                    Size = fileInfo.Length
                };
                System.IO.File.Delete(fileToDelete);
                return new DataResult<ImageDeletedDto>(ResultStatus.Succes, imageDeletedDto);
            }
            return new DataResult<ImageDeletedDto>(ResultStatus.Error, "Şəkil Tapılmadı", null);
        }

        //public string UploadImage(string name, IFormFile pictureFile, PictureType pictureType, string folderName=null)
        //{
        //    folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;
        //    if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
        //    {
        //        Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
        //    }
        //    string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
        //    string fileExtension = Path.GetExtension(pictureFile.FileName);

        //    Regex regex = new Regex("[*'\", .|_&#^@]");
        //    name = regex.Replace(name,string.Empty);

        //    DateTime dateTime = DateTime.Now;
        //    //TuralAbdulxaliqov/542_5_10_12_2020.png
        //    string newFileName = $"{name}_{dateTime.FullDateAndStringWithUnderScore()}_{fileExtension}";
        //    string path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
        //    using (var stream = new FileStream(path, FileMode.Create))
        //    {
        //        pictureFile.CopyTo(stream);
        //    }
        //    string message = pictureType == PictureType.User ? $"{name} adlı istifadəçinin şəkli uğurla yükləndi."
        //        : $"{name} adlı məqalənin şəkli uğurla yükləndi.";
        //    return $"{folderName}/{newFileName}";
        //}

        public async Task<IDataResult<ImageUploadedDto>> UploadImage(string name, IFormFile pictureFile, PictureType pictureType, string folderName = null)
        {

            folderName ??= pictureType == PictureType.User ? userImagesFolder : postImagesFolder;
            if (!Directory.Exists($"{_wwwroot}/{imgFolder}/{folderName}"))
            {
                Directory.CreateDirectory($"{_wwwroot}/{imgFolder}/{folderName}");
            }
            string oldFileName = Path.GetFileNameWithoutExtension(pictureFile.FileName);
            string fileExtension = Path.GetExtension(pictureFile.FileName);

            Regex regex = new Regex("[*/:'\", .|_&#^@]");
            name = regex.Replace(name, string.Empty);

            DateTime dateTime = DateTime.Now;
            //TuralAbdulxaliqov/542_5_10_12_2020.png
            string newFileName = $"{name}_{dateTime.FullDateAndStringWithUnderScore()}_{fileExtension}";
            string path = Path.Combine($"{_wwwroot}/{imgFolder}/{folderName}", newFileName);
            await using (var stream = new FileStream(path, FileMode.Create))
            {
                await pictureFile.CopyToAsync(stream);
            }
            string message = pictureType == PictureType.User ? $"{name} adlı istifadəçinin şəkli uğurla yükləndi."
                : $"{name} adlı məqalənin şəkli uğurla yükləndi.";
            return new DataResult<ImageUploadedDto>(ResultStatus.Succes, message, new ImageUploadedDto
            {
                FullName = $"{folderName}/{newFileName}",
                OldName = oldFileName,
                Extension = fileExtension,
                FolderName = folderName,
                Path = path,
                Size = pictureFile.Length
            });
        }
    }
}
