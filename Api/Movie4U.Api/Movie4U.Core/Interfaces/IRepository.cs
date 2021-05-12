using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> Filter(Expression<Func<T, bool>> predicate);

        T GetById(int id);

        T Add(T entity);

        T Update(T entity);

        int SaveChanges();

    }
}
