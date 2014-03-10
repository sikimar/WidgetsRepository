﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidgetsRepository.DAL
{
    public interface IData<T>
    {
        T Id { get;set; }
        object Data { get; set; }
    }
}
