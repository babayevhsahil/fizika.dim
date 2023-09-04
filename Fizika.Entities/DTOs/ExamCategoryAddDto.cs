using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ExamCategoryAddDto:DtoGetBase
    {
        [DisplayName("Sınaq və ya Qəbul ili")]
        [Required(ErrorMessage = "{0} adı boş ola bilməz!")] //{O} = Kateqoriya Adı
        [MaxLength(60, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")] //{1} = 70
        public string Name { get; set; }
      
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0}  boş ola bilməz!")]
        public bool IsActive { get; set; }
    }
}
