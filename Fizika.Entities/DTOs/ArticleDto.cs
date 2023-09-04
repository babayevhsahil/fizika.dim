using Fizika.Shared.Entities.Abstract;
using Fizika.Shared.Utilities.Results.ComplexTypes;
using Fizika.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ArticleDto:DtoGetBase
    {
        public Article Article { get; set; }
    }
}
