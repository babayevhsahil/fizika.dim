using Fizika.Shared.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class StudentsAddDto:DtoGetBase
    {
        [DisplayName("AdSoyad")]
        [MaxLength(60, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Fullname { get; set; }
        [DisplayName("Universitet")]
        [MaxLength(50, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string University { get; set; }
        [DisplayName("Universitet bali")]
        [MaxLength(10, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        public string Point { get; set; }
        [DisplayName("Fizika bali")]
        [MaxLength(10, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        public string PointPhysic { get; set; }
        [DisplayName("Şəkil")]
        [Required(ErrorMessage = "Zəhmət olmasa {0} seçin")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Photo { get; set; }
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0}  boş ola bilməz!")]
        public bool IsActive { get; set; }
    }
}
