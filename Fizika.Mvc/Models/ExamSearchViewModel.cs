using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class ExamSearchViewModel
    {
        public ExamListDto ExamListDto { get; set; }
        public string Keyword { get; set; }
    }
}
