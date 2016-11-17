using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Models.Entitys
{
    public class User : ColaNet.Core.Entities.Entity
    {
        public virtual string Name { get; set; }
       
    }
}
