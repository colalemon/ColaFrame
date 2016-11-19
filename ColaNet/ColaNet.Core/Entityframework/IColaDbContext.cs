using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ColaNet.Core.Entityframework
{
    public interface IColaDbContext : IDependency
    {
        DbContext dbcontext { get; set; }
    }
}
