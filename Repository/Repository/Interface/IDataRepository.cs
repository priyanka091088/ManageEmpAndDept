using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IDataRepository<E>
    {
        IEnumerable<E> GetAllData();

        bool Create(E entity);
        bool Update(E entity);
        bool Delete(E entity);

    }
}
