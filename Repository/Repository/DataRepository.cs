using Microsoft.Practices.Unity;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        #region Private variables

        private DbContext _dbContext;
        private DbSet<T> _objSet;
        private IUnityContainer _container;

        public DataRepository(IUnityContainer container)
        {
            this._container = container;
            this._dbContext = this._container.Resolve<DbContext>();
            this._objSet = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAllData()
        {
            return _objSet;
        }

        public bool Create(T entity)
        {
            try
            {
                _objSet.Add(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _objSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                    _objSet.Attach(entity);
               
                _objSet.Remove(entity);
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
