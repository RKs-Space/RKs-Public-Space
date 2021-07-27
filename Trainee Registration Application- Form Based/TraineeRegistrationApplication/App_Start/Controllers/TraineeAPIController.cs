using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TraineeRegistrationApplication.Models;

namespace TraineeRegistrationApplication.App_Start.Controllers

{
    public class TraineeAPIController : ApiController
    {
        FileInfo yes;

        [System.Web.Mvc.HttpPost]
        public string UploadFile()
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/ApiUpload"), httpPostedFile.FileName);

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                     yes = new FileInfo(fileSavePath);

                     
                     return yes.ToString(); 
                }
                
            }
            return "Didnt go inside";
        }


        public string MyFunction()
        {
            string pat1="Initial Path.null";
            string pat = "";
            string path = @"E:\Endeavour\COGNIZANT\Post Joining\NET-Platforms\Mini-Module\TraineeRegistrationApplication\TraineeRegistrationApplication\Content\ApiUpload";
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo flInfo in dir.GetFiles())
            {
                pat1 = flInfo.ToString();
                pat = @"E:\Endeavour\COGNIZANT\Post Joining\NET-Platforms\Mini-Module\TraineeRegistrationApplication\TraineeRegistrationApplication\Content\ApiUpload\"+pat1;
            }
            if (pat == "")
            {
                return "No file choosen";
            }
            else
            {
                Array.ForEach(Directory.GetFiles(@"E:\Endeavour\COGNIZANT\Post Joining\NET-Platforms\Mini-Module\TraineeRegistrationApplication\TraineeRegistrationApplication\Content\ApiUpload"), File.Delete);

                return pat;
                            }
            //FileStream fs = new FileStream(pat, FileMode.Open, FileAccess.Read);
            //// Create a byte array of file stream length
            //byte[] ImageData = new byte[fs.Length];
            ////Read block of bytes from stream into the byte array
            //fs.Read(ImageData, 0, System.Convert.ToInt32(fs.Length));

            //fs.Close();
                
            //return ImageData;
        }

        

   }
}

