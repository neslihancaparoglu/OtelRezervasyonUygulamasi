﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IRepositoryUser User { get; }
        IRepositoryUser Room { get; }
        Task SaveAsync();
    }
}
