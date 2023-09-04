using Fizika.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fizika.Mvc.Models
{
    public class ArticleSearchViewModel
    {
        public ArticleListDto  ArticleListDto { get; set; }
        public string Keyword { get; set; }
    }
}
