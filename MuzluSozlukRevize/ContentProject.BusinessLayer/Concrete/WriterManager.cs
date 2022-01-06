using ContentProject.BusinessLayer.Abstract;
using ContentProject.BusinessLayer.Result;
using ContentProject.DataAccessLayer.Context;
using ContentProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.Concrete
{
    public class WriterManager : ManagerBase<Writer>
    {
        public bool UsernameMatchs(string username, string mail)
        {
            var user = base.Get(x => x.WriterUsername == username || x.WriterPassword == mail);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}

