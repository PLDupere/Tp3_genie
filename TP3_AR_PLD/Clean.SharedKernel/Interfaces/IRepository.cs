using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        int Update<T>(T entity) where T : BaseEntity;
        int Delete<T>(T entity) where T : BaseEntity;
    }
}
