using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonoliticoWebApp.ORM
{
    public class EntityBase<T>
    {
        public virtual int Id { get; set; }
    }
}