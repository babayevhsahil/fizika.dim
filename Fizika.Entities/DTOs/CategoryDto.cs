using Fizika.Shared.Entities.Abstract;
using Fizika.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class CategoryDto:DtoGetBase
    {
        public Category Category { get; set; }
    }
}
