﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fizika.Shared.Utilities.Results.ComplexTypes
{
    public enum ResultStatus
    {
        Succes = 0,
        Error = 1,
        Warning = 2, //ResultStatus.Warning
        Info = 3,
        Authentication = 4,
        Authorization = 5
    }
}
