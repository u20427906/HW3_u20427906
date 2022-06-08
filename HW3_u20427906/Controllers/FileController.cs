using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3_u20427906.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult File()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Documents"));
            List<Models.FileModel> files = new List<Models.FileModel>(); 

            foreach(string filePath in filePaths)
            {
                files.Add(new Models.FileModel { fileName = Path.GetFileName(filePath) });
            }
            

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Server.MapPath("~/Media/Documents/")  + fileName;

          
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {

            string path = Server.MapPath("~/Media/Documents/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);

            return RedirectToAction("File");
        }

    }
}