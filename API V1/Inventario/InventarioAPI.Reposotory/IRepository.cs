using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioAPI.Reposotory
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(long id);
        Task Add(TEntity data);
        void Delete(long id);
        void Update(TEntity data);
        Task Save();
    }
}
