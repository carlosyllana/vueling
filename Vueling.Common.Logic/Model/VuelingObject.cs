﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Logic.Model
{
    
    public abstract class VuelingObject
    {

        public virtual  Guid Guid { get; set; }  

    }
}
