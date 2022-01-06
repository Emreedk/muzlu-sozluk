
using ContentProject.BusinessLayer.Abstract;
using ContentProject.DataAccessLayer.EntityFramework;
using ContentProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.Concrete
{
    public class CategoryManager : ManagerBase<Category>
    {
        

        //public List<Category> GetAll()
        //{
        //    return repo_cat.List();
        //}

        //public void CategoryAdd(Category p)
        //{


        //    if (p.CategoryName == "" || p.CategoryName.Length < 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {

        //    }
        //    else
        //    {
        //        repo_cat.Insert(p);
        //    }
        //}
        
    }
}
