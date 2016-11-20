using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Entityframework;
using System.Data.Entity;
using System.Reflection;

namespace ColaNet.Core.Repositories
{
    public class Repository<T, K> : IRepository<T, K>
        where T : class
    {
        public readonly DbContext _colaEntities;

        public readonly IColaDbContext _colaDbContext;


        public Repository(IColaDbContext colaDbcontext)
        {
            _colaDbContext = colaDbcontext;
            _colaEntities = _colaDbContext.dbcontext;

        }

        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T Get(K Id)
        {
            var parms = Expression.Parameter(typeof(T), "b");
            var parms_property = Expression.Property(parms, "Id");
            var equalVale = Expression.Constant(Id, typeof(K));
            var body = Expression.Equal(parms_property, equalVale);
            var lam = Expression.Lambda<Func<T, bool>>(body, parms);

            var query = _colaEntities.Set<T>().Where(lam);

            if (query.Count() == 0)
                return null;
            else
                return query.ElementAt(0);


        }

        /// <summary>
        /// 异步获取单个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>

        public async Task<T> GetAsync(K Id)
        {
            var _result = await Task.Run<T>(() =>
            {
                return Get(Id);
            });
            return _result;
        }

        /// <summary>
        /// 根据条件获取实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> GetAll(Expression<Func<T, bool>> where)
        {
            var query = _colaEntities.Set<T>().Where(where);
            return query.ToList();
        }

        /// <summary>
        /// 异步根据条件获取实体列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where)
        {
            var _result = await Task.Run<List<T>>(() =>
            {
                return GetAll(where);
            });
            return _result;
        }

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>

        public T Add(T entity)
        {
            _colaEntities.Set<T>().Add(entity);
            _colaEntities.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 异步添加一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> AddAsync(T entity)
        {
            var _result = await Task.Run<T>(() =>
            {
                return Add(entity);
            });
            return _result;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(K Id)
        {
            T entity = Get(Id);

            PropertyInfo[] pros = typeof(T).GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                if (pro.Name == "IsSoftDelete")
                {
                    pro.SetValue(entity, true);
                }
            }
            _colaEntities.Set<T>().Attach(entity);
            _colaEntities.SaveChanges();
            return true;
        }

        /// <summary>
        /// 异步删除一个实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(K Id)
        {
            var _result = await Task.Run<bool>(() =>
            {
                return Delete(Id);
            });
            return _result;

        }

        /// <summary>
        /// 跟新一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Update(T entity)
        {
            _colaEntities.Set<T>().Attach(entity);
            _colaEntities.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 异步跟新一个实体 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<T> UpdateAsync(T entity)
        {
            var _result = await Task.Run<T>(() =>
            {
                return Update(entity);
            });
            return entity;
        }
    }

    public class Repository<T> : Repository<T, long>, IRepository<T> where T : class
    {
        public Repository(IColaDbContext colaDbcontext)
            : base(colaDbcontext)
        {

        }
    }
}
