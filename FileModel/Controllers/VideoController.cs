using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace FileModel.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()

        {

            List<Models.FileClass> files = new List<Models.FileClass>();

            foreach (string filePaths in Directory.GetFiles(Server.MapPath("~/Media/Video")))
            {
                FileInfo fileInfo = new FileInfo(filePaths);
                Models.FileClass objec = new Models.FileClass();
                objec.FileName = fileInfo.Name;
                files.Add(objec);
            }
            return View(files);
        }
        public FileResult DownloadFile(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Video"), fileName);
            byte[] filebytes = System.IO.File.ReadAllBytes(fullpath);
            return File(filebytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult DeleteFile(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Video"), fileName);
            FileInfo file = new FileInfo(fullpath);
            System.IO.File.Delete(fileName);
            file.Delete();
            return RedirectToAction("Index");
        }
    }
}