using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class StudentAjaxViewModel
    {
        public StudentsAddDto StudentAddDto{ get; set; }
        public string StudentAddPartial { get; set; }
        public StudentsDto StudentDto{ get; set; }
    }
}
