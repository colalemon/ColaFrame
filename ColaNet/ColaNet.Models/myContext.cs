using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColaNet.Core.Entityframework;
using System.Data.Entity;
using ColaNet.Models.Entitys;

namespace ColaNet.Models
{
    public class myContext :ColaDbContext

    {
        public virtual IDbSet<User> Users { get; set; }
        public myContext()
            : base("Default")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(entity => entity.ToTable(entity.ClrType.Name));
            base.OnModelCreating(modelBuilder);

        }
    }
}
