﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Shared.Entities.Abstract
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
