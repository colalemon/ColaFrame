using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ColaNet.Core.Interceptor;
using Autofac.Extras.DynamicProxy;



namespace ColaNet.Core.Repositories
{
    [Intercept(typeof(AopIntercept))]
    public interface IRepository<T, K>
        where T : class
    {
        T Get(K Id);

        Task<T> GetAsync(K Id);

        IQueryable<T> GetAll(Expression<Func<T, bool>> where);

        Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> where);

        List<T> GetAllList(Expression<Func<T, bool>> where);

        Task<List<T>> GetAllListAsync(Expression<Func<T, bool>> where);

        T Add(T entity);

        Task<T> AddAsync(T entity);

        bool Delete(K Id);

        Task<bool> DeleteAsync(K Id);

        T Update(T entity);

        Task<T> UpdateAsync(T entity);
    }

    public interface IRepository<T> : IRepository<T, long> where T : class
    {

    }
}
