using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class HomeViewModel
    {
        public ArticleListDto ArticleListDto { get; set; }
        public StudentsListDto StudentsListDto { get; set; }
        public ExamListDto ExamListDto { get; set; }
        public VideoListDto VideoListDto { get; set; }
    }
}
