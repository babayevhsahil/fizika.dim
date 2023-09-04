using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Areas.Admin.Models
{
    public class TeamUpdateAjaxViewModel
    {
        public StudentsUpdateDto  StudentUpdateDto { get; set; }
        public StudentsDto  StudentDto  { get; set; }
        public string StudentUpdatePartial { get; set; }
    }
}
