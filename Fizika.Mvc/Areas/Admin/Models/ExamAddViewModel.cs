using Fizika.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class ExamAddViewModel
    {
        [DisplayName("Sınaq adı və ya Qəbul Adı")]
        [Required(ErrorMessage = "{0} adı boş ola bilməz!")] //{O} = Kateqoriya Adı
        [MaxLength(80, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")] //{1} = 70
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")] //{1} = 3
        public string ExamName { get; set; }
        [DisplayName("Müəllim Adı")]
        [Required(ErrorMessage = "{0} adı boş ola bilməz!")]
        [MaxLength(70, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Teacher { get; set; }
        [DisplayName("Test Tarixi")]
        [Required(ErrorMessage = "{0} adı boş ola bilməz!")]
        [MaxLength(20, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(1, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string ExamYear { get; set; }
        [DisplayName("Tarix")]
        [Required(ErrorMessage = "{0} sahəsi boş ola bilməz")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayName("Fayl Pdf")]
        [Required(ErrorMessage = "{0} sahəsi boş ola bilməz")]
        public IFormFile Link { get; set; }
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0} boş ola bilməz!")]
        public bool IsActive { get; set; }
        [DisplayName("Kateqoriya")]
        [Required(ErrorMessage = "{0} sahəsi boş ola bilməz")]
        public int ExamCategoryId { get; set; }
        public IList<ExamCategory> ExamCategories { get; set; }
    }
}
