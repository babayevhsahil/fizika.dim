﻿using Fizika.Entities.Concrete;
using Fizika.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Entities.DTOs
{
    public class ExamCategoryDto:DtoGetBase
    {
        public ExamCategory ExamCategory { get; set; }
    }
}
