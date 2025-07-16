﻿using StudentSystem.Abstract;
using System.Linq.Expressions;

namespace StudentSystem.REPO.Contracts
{
    public interface IBaseRepo<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool track = true);
        IQueryable<T>GetByCondition(Expression<Func<T, bool>> condition, bool track = true);
        T? GetById(int id);
        void Create(T entity);  
        void Update(T entity);
        void Delete(T entity,bool softDelete=true);
    }
}
