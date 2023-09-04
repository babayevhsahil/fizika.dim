using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class BusinessAddViewModel
    {
        [DisplayName("Biznes Başlığı")]
        [MaxLength(50, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Header { get; set; }
        [DisplayName("Biznes Açıqlaması")]
        [MaxLength(200, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Description { get; set; }
        [DisplayName("Şəkil")]
        [Required(ErrorMessage = "Zəhmət olmasa {0} seçin")]
        [DataType(DataType.Upload)]
        public IFormFile PictureFile { get; set; }
        public string Icon { get; set; }
        [DisplayName("Aktivdir mi ?")]
        [Required(ErrorMessage = "{0} boş ola bilməz!")]
        public bool IsActive { get; set; }
    }
}
