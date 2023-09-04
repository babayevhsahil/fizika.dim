using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class RegisterAddAjaxViewModel
    {
        public RegisterAddDto RegisterAddDto { get; set; }
        public string RegisterAddPartial { get; set; }
        public RegisterDto RegisterDto { get; set; }
    }
}
