using ContentProject.Entity.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentProject.BusinessLayer.Result
{
    public class BusinessLayerResult<T> where T : class
    {
        public List<ErrorMessageObj> Errors { get; set; }
        public T Result { get; set; }

        public BusinessLayerResult()
        {
            Errors = new List<ErrorMessageObj>();
        }

        public  void    AddError(ErrorMessageCode code, string msg)
        {
            Errors.Add(new ErrorMessageObj() { Code = code, Message = msg });
        }
    }
}
