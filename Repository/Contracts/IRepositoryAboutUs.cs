﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryAboutUs : IRepositoryBase<AboutUs>
    {
        IQueryable<AboutUs> GetAboutUs(int id, bool trackchanges);
    }
}
