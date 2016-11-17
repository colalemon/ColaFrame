using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ColaNet.Core.Entityframework
{
    public class ColaDbContext:DbContext
    {
        public ColaDbContext() { }

        public DbContext dbContext { get; set; }
        public ColaDbContext(string connStr)
            : base(connStr)
        {
        }
    }
}
