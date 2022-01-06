using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        int Insert(T obj);

        int Delete(T obj);

        T Get(Expression<Func<T, bool>> filter);

        int Update(T obj);

        List<T> List(Expression<Func<T, bool>> filter);

        int Save();
    }
}
