using ContentProject.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.DataAccessLayer.EntityFramework
{
    public class Repository<T> :RepositoryBase, IRepository<T> where T : class
    {
        private DbSet<T> _objectSet;
        public Repository()
        {
            _objectSet = db.Set<T>();  //Repository her kullanıldığında DbContext'in set metodu çalışacak.
        }

        public int Delete(T obj) //Silmek yerine controllerda isActive'i false yapıp sadece update etmesini istedim.
        {
            //var deletedEntity = db.Entry(obj);
            //deletedEntity.State = EntityState.Deleted;
           // _objectSet.Remove(obj);
            return Update(obj);


        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _objectSet.SingleOrDefault(filter);
        }

        public int Insert(T obj)
        {
            var addedEntity = db.Entry(obj);
            addedEntity.State = EntityState.Added;
            //_objectSet.Add(obj);
            return Save();

        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _objectSet.Where(filter).ToList();
        }

        public int Save()
        {
            
            return db.SaveChanges();
        }

        public int Update(T obj)
        {
            var updatedEntity = db.Entry(obj);
            updatedEntity.State = EntityState.Modified;
            return Save();
        }
    }
}
