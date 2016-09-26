using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity : BaseEntity, IEntity
    {
        public virtual long Id { get; set; }
    }

}
