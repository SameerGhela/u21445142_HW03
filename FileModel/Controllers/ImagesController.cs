using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace FileModel.Controllers
{
    public class ImagesController : Controller
    {
        // GET: Images
        public ActionResult Images()
        {
            //Fetch all files in the Folder (Directory)
            //Copy File names to Model collection.
            //The return below returns to the list here.

            List<Models.FileClass> files = new List<Models.FileClass>();

            foreach (string filePaths in Directory.GetFiles(Server.MapPath("~/Media/Images")))
            {
                FileInfo fileInfo = new FileInfo(filePaths);
                Models.FileClass obj = new Models.FileClass();
                obj.FileName = fileInfo.Name;
                files.Add(obj);
            }
            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
            byte[] filebytes = System.IO.File.ReadAllBytes(fullpath);
            return File(filebytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
        public ActionResult DeleteFile(string fileName)
        {
            string fullpath = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
            FileInfo file = new FileInfo(fullpath);
            System.IO.File.Delete(fileName);
            file.Delete();
            return RedirectToAction("Images");
        }
    }
    
}