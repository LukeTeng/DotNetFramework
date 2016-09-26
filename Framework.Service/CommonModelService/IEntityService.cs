using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;

namespace Framework.Service
{
    public interface IEntityService<T> : IService 
        where T: BaseEntity 
    {
        bool Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);

        T GetById(long id);
    }
}
