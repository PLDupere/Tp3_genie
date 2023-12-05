using Clean.SharedKernel.Interfaces;
using Clean.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.SharedKernel.Interfaces;

namespace Clean.Infrastructure.Repositories
{
    public class EfRepository<T> :  IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly CleanContext _CleanContext;

        public EfRepository(CleanContext cleanContext)
        {
            _CleanContext = cleanContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _CleanContext.Set<T>().Find(id);
        }

        public List<T> List<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
               _CleanContext.Set<T>().Add(entity);
               _CleanContext.SaveChanges();
               return entity;
        }

        public int Update<T>(T entity) where T : BaseEntity
        {
            _CleanContext.Entry(entity).State = EntityState.Modified;
            return _CleanContext.SaveChanges();
        }

        public int Delete<T>(T entity) where T : BaseEntity
        {
            _CleanContext.Set<T>().Remove(entity);
            return _CleanContext.SaveChanges();
        }
    }
}
