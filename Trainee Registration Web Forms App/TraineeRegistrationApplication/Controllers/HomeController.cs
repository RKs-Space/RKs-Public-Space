using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraineeRegistrationApplication.Models;
using System.IO;
using Newtonsoft.Json;

namespace TraineeRegistrationApplication.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult version2()
        {
            return View();
        }

        

      
        public ActionResult Files()
        {
             
            return View(); 
        }

        [HttpPost]
        public ActionResult Files(Picture picture)
        {
            FileInfo yes;

            if (picture.File.ContentLength > 0)
            {
                var filename = Path.GetFileName(picture.File.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/ApiUpload"), filename);
                picture.File.SaveAs(path);
                yes = new FileInfo(path);


                //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                //// Create a byte array of file stream length
                //byte[] ImageData = new byte[fs.Length];
                ////Read block of bytes from stream into the byte array
                //fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

                //fs.Close();
                
                ViewBag.result = yes.ToString();

            }
            
            
            return View();
        }

    }
}
