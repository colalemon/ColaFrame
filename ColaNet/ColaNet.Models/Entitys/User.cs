using ColaNet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaNet.Models.Entitys
{
    public class User : Entity
    {
        public virtual string Name { get; set; }
       
    }
}
