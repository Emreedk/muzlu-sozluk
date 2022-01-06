
using ContentProject.BusinessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;
using System.Web.Mvc;
using ContentProject.Entity.Concrete;
namespace ContentProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        HeadingManager hm = new HeadingManager();
        ContentManager ctm = new ContentManager();
        // GET: Home
        public PartialViewResult Contents(int? id,int c=1)
        {
            if (id == null)
            {
                var headings = hm.List();
                List<Content> contents = new List<Content>();
                Random rnd = new Random();
                //foreach (var heading in headings)
                //{
                //    var contentList = ctm.List(x => x.HeadingId == heading.HeadingId);
                //    if (contentList.Count == 0) continue;
                //    int r = rnd.Next(0, contentList.Count);

                //    //int value = rnd.Next(contentList.IndexOf(contentList.FirstOrDefault()), contentList.IndexOf(contentList.LastOrDefault()));
                //    contents.Add(contentList[r]);


                //}

                while (contents.Count<10) { 
                    var heading = headings[rnd.Next(0, headings.Count)];
                    var contentList = ctm.List(x => x.HeadingId == heading.HeadingId);
                    if (contentList.Count != 0)
                    {
                        int r = rnd.Next(0, contentList.Count);
                        contents.Add(contentList[r]);
                    }
                }              
                
                return PartialView(contents.ToPagedList(c,10));
            }

            var a = ctm.List(x => x.HeadingId == id).Where(x=> x.isActive == true).OrderByDescending(x => x.ContentDate).ToList();
            return PartialView(a.ToPagedList(c,10));

        }

        public ActionResult Headings(int p = 1)
        {

            return View(hm.List().Where(x => x.isActive == true).OrderByDescending(x => x.HeadingDate).ToPagedList(p, 10));
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }
}