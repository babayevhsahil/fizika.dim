using Fizika.Entities.Concrete;
using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class AboutViewModel
    {
        public  AboutUsPageInfo aboutUsPageInfo { get; set; }
        public  ChooseUsPageInfo chooseUsPageInfo { get; set; }
        public StudentsListDto StudentsListDto { get; set; }
    }
}
