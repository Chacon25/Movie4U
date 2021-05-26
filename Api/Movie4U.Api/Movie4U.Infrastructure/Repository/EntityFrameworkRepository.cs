using Microsoft.EntityFrameworkCore;
using Movie4U.Core.Entities;
using Movie4U.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Infrastructure.Repository
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        private Movie4UDbContext _movie4UDbContext;

        public EntityFrameworkRepository(Movie4UDbContext movie4UDbContext)
        {

            _movie4UDbContext = movie4UDbContext;

        }
        public T Add(T entity)
        {
            
            _movie4UDbContext.Add(entity);
            _movie4UDbContext.SaveChanges();
            return entity;
        }
    


        public IEnumerable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _movie4UDbContext.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _movie4UDbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _movie4UDbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }



        public User GetByName(string Name)
        {
            return _movie4UDbContext.Set<User>().FirstOrDefault(x => x.Name == Name);
        }
        public int SaveChanges()
        {
            return _movie4UDbContext.SaveChanges();
        }

        public T Update(T entity)
        {

            T updated = _movie4UDbContext.Update(entity).Entity;
            _movie4UDbContext.SaveChanges();
            return updated;
        }

    
    }
}
