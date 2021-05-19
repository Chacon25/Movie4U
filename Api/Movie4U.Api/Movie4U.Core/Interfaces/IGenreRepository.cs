﻿using Movie4U.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> GetById(int id);
        Task<IEnumerable<Genre>> GetInfoByIds(Expression<Func<Genre, bool>> predicate);
    }
}
