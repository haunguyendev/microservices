﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Domains.Interfaces
{
    public interface IDateTracking
    {
        DateTimeOffset CreateDate { get; set; }
        DateTimeOffset? LastModifiedDate { get; set; }  
    }
}
