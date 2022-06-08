using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileModel;

namespace FileModel.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]

        public ActionResult Index(HttpPostedFileBase files, string Filetype)
            
        {
            ViewBag.Message = Filetype;
            if(files != null && files.ContentLength>0)
            {
                var filename = Path.GetFileName(files.FileName);
                string path;
                switch (ViewBag.Message)
                {
                    case "Document":
                        path = Path.Combine(Server.MapPath("~/Media/Document"), filename);
                        files.SaveAs(path);
                        break;
                    case "Images":
                        path = Path.Combine(Server.MapPath("~/Media/Images"), filename);
                        files.SaveAs(path);
                        break;
                    case "Video":
                        path = Path.Combine(Server.MapPath("~/Media/Video"), filename);
                        files.SaveAs(path);
                        break;
                }
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {

            return View();
        }

        
    }
}