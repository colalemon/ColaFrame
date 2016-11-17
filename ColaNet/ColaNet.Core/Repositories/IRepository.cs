using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;



namespace ColaNet.Core.Repositories
{
    public interface IRepository<T, K>
        where T : class
    {
        T Get(K Id);

        Task<T> GetAsync(K Id);

        List<T> GetAll(Expression<Func<T, bool>> where);

        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);

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
