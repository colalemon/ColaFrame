using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Core.Entities
{

    /// <summary>
    /// 用户实体
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntity<T> : IIsoftDelete
    {
        T Id { get; set; }

    }

    /// <summary>
    /// 软删除
    /// </summary>
    public interface IIsoftDelete
    {
        bool IsSoftDelete { get; set; }
    }


    public class Entity<T> : IEntity<T>
    {
        [Key]
        public virtual T Id { get; set; }
        public virtual bool IsSoftDelete { get; set; }
    }

    public class Entity : IEntity<long>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }

        public virtual bool IsSoftDelete { get; set; }
    }
}
