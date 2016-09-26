using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Model;
using System.Data.Entity;

namespace Framework.Service
{
    public abstract class EntityService<T> : IEntityService<T> 
        where T : BaseEntity
    {

        protected IContext _context;
        protected IDbSet<T> _dbset;

        public EntityService(IContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public bool Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity when create");
            }

            _dbset.Add(entity);
            _context.SaveChanges();

            return true;
        }



        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity when delete");
            }

            _dbset.Remove(entity);
            _context.SaveChanges();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity when update");
            }

            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public T GetById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("entity when GetById");
            }

            return _dbset.Find(id);

        }

    }
}
