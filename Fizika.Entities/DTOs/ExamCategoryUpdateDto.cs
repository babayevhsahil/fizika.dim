using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ExamCategoryUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Sınaq və ya Qəbul ili")]
        [MaxLength(60, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")] //{1} = 70
        public string Name { get; set; }
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0}  boş ola bilməz!")]
        public bool IsActive { get; set; }
        [DisplayName("Silinib ?")]
        [Required(ErrorMessage = "{0} boş ola bilməz!")]
        public bool IsDeleted { get; set; }
    }
}
