using Microsoft.EntityFrameworkCore;
using StudentSystem.Abstract;
using StudentSystem.Context;
using StudentSystem.REPO.Contracts;
using System.Linq.Expressions;

namespace StudentSystem.REPO.Concretes
{
    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected BaseRepo(AppDbContext context)
        {
            _context = context;
        }
        public void Create(T entity)=>_context.Set<T>().Add(entity);

        public void Delete(T entity, bool softDelete = true)
        {
            if(softDelete)
            {
                entity.IsDeleted = true; // Assuming BaseEntity has an IsDeleted property
                _context.Set<T>().Update(entity);
            }
            else
            {
                _context.Set<T>().Remove(entity);
            }
        }

        public IQueryable<T> GetAll(bool track = true)=> track? 
            _context.Set<T>() : _context.Set<T>().AsNoTracking();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition, bool track = true)=> track ?
            _context.Set<T>().Where(condition) : _context.Set<T>().Where(condition).AsNoTracking();

        public T? GetById(int id)
        => _context.Set<T>().Find(id);  
        public void Update(T entity)
        {
           entity.UpdatedAt=DateTime.UtcNow; // Assuming BaseEntity has an UpdatedAt property
            _context.Set<T>().Update(entity);
        }
    }
}
