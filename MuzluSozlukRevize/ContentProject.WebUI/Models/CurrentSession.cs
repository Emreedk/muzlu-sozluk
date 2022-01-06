using ContentProject.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContentProject.WebUI.Models
{
    public class CurrentSession
    {
        public static Writer Writer
        {
            get { return Get<Writer>("Username"); }
        }



        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }
            return default(T);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear(string key)
        {
            HttpContext.Current.Session.Clear();
        }
    }
}