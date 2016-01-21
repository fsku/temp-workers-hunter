using System.Collections.Generic;
using TemporaryWorkersHunter.Entities.Common;

namespace TemporaryWorkersHunter.Service.Common
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();      
        void Update(T entity);
    }
}
