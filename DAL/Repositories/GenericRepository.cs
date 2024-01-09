using DAL.Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly DbContext.AuthDbContext _AuthDbContext;

        public GenericRepository(DbContext.AuthDbContext recipeDbContext)
        {
            _AuthDbContext = recipeDbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _AuthDbContext.Set<T>().ToList();
        }

        public void Add(T entity)
        {

            _AuthDbContext.Add(entity);
            _AuthDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _AuthDbContext.Update(entity);
            _AuthDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _AuthDbContext.Remove(entity);
            _AuthDbContext.SaveChanges();
        }

        public T GetById(int id)
        {
            return _AuthDbContext.Set<T>().Find(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return _AuthDbContext.Set<T>();
        }
        public void AddRange(IEnumerable<T> entities)
        {
            _AuthDbContext.AddRange(entities);
            _AuthDbContext.SaveChanges();
        }
    }
}
