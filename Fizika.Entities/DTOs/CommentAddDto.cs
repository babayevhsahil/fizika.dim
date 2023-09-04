﻿using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class CommentAddDto:DtoGetBase
    {
        
        [DisplayName("Şərh")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(1000, ErrorMessage ="{0} {1} karakterdən böyük olmamalıdır. ")]
        [MinLength(2, ErrorMessage ="{0} {1} karakterdən kiçik olmamalıdır. ")]
        public string Text { get; set; }
        [DisplayName("Ad Soyad")]
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterdən böyük olmamalıdır. ")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterdən kiçik olmamalıdır. ")]
        public string CreatedByName { get; set; }
        [Required(ErrorMessage = "{0} boş olmamalıdır.")]
        public int ArticleId { get; set; }
    }
}
