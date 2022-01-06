using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.Core
{
    public interface IDataAccess<T>
    {

        List<T> List();

        int Insert(T obj);

        int Delete(T obj);

        int Update(T obj);

        T Get(Expression<Func<T, bool>> filter);

        List<T> List(Expression<Func<T, bool>> filter);

        int Save();
    }
}
