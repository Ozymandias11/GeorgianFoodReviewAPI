using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        private RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) => _repositoryContext = repositoryContext;

        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);
       

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);


        //Retrieves all entities of type T from the repository context
        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ?
            _repositoryContext.Set<T>().AsNoTracking() :
            _repositoryContext.Set<T>();

       

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? 
            _repositoryContext.Set<T>().AsNoTracking().Where(expression) :
            _repositoryContext.Set<T>().Where(expression);




        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);
       
    }
}
