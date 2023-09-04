using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class BusinessUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [DisplayName("Biznes Başlığı")]
        [MaxLength(50, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Header { get; set; }
        [DisplayName("Biznes Açıqlaması")]
        [MaxLength(200, ErrorMessage = "{0} {1} - dən böyük ola bilməz!")]
        [MinLength(3, ErrorMessage = "{0} {1} - dən az ola bilməz!")]
        public string Description { get; set; }
        [DisplayName("Şəkil")]
        public string Icon { get; set; }
        [DisplayName("Aktivdir mi ?")]
        [Required(ErrorMessage = "{0} boş ola bilməz!")]
        public bool IsActive { get; set; }
        [DisplayName("Silinib ?")]
        [Required(ErrorMessage = "{0} boş ola bilməz!")]
        public bool IsDeleted { get; set; }
    }
}
