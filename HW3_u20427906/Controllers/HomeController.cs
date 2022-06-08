using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace HW3_u20427906.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            var SelectedFile = Request["DocType"].ToString();

            if (files != null && files.ContentLength > 0)
            {
                
                var fileName = Path.GetFileName(files.FileName);

                if (SelectedFile == "Documents")
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Documents"), fileName);
                    files.SaveAs(path);
                }

                else if(SelectedFile == "Images")
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Images"), fileName);
                    files.SaveAs(path);
                }

                else if (SelectedFile == "Videos")
                {
                    var path = Path.Combine(Server.MapPath("~/Media/Videos"), fileName);
                    files.SaveAs(path);
                }
                    
                
            }
          
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "My Biography";

            return View();
        }

 
    }
}