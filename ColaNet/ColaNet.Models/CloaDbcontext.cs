using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Entityframework;
using System.Data.Entity;

namespace ColaNet.Models
{
    public class CloaDbcontext:IColaDbContext
    {
        public DbContext dbcontext { get; set; }
        public CloaDbcontext()
        {
            dbcontext = (DbContext)new myContext();
        }
    
    }
}
