using ContentProject.Core;
using ContentProject.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.Abstract
{
    public class ManagerBase<T> : IDataAccess<T> where T : class
    {
        private Repository<T> repo = new Repository<T>();
        public int Delete(T obj)
        {
            return repo.Delete(obj);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return repo.Get(filter);
        }

        public int Insert(T obj)
        {
            return repo.Insert(obj);
        }

        public List<T> List()
        {
            return repo.List();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return repo.List(filter);
        }

        public int Save()
        {
            return repo.Save();
        }

        public int Update(T obj)
        {
            return repo.Update(obj);
        }
    }
}
