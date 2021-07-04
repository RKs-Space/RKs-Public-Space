using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Spire.Xls;
using IronBarCode;

namespace BarCodeGen.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> fonts = new List<SelectListItem>();
        private void setFontfamily()
        {
            IList<string> fontNames = FontFamily.Families.Select(f => f.Name).ToList();
            foreach (var item in fontNames)
            {
                fonts.Add(new SelectListItem { Text = item.ToString(), Value = item.ToString() });
            }
            ViewData["FontFamilies"] = fonts;
            List<BarcodeEncoding> codeTypes = Enum.GetValues(typeof(BarcodeEncoding)).Cast<BarcodeEncoding>().ToList();
            List<string> stringBar = (from o in codeTypes select o.ToString()).ToList();
            stringBar.Select(m => new SelectListItem { Text = m, Value = m });
            ViewBag.barTypes = stringBar;
        }
        public ActionResult Index()
        {
            setFontfamily();
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection fc)
        {
            setFontfamily();
            string barType = fc["BarType"];
            string product = fc["Product"];
            string barHeight = fc["bHeight"];
            string barWidth = fc["bWidth"];
            string fontFamily = fc["fontFamily"];
            string fontSize = fc["fSize"];
            
            //add default value for heigth,width,font,size & make it non mandatory in view

            //List<string> barCodes = 
                BarGen(barType, barHeight, barWidth, fontFamily, fontSize);
            //if (barCodes!=null)
            //{
            //    ViewData["BarCodesGenerated"] = barCodes;
            //    ViewBag.BarFeeded = "Ready to Print";
            //}
            if (Directory.Exists(Server.MapPath("~/UploadsDirectory")))
            {
                Directory.Delete(Server.MapPath("~/UploadsDirectory"), true);
            }
            return View("Index");
        }


        [HttpPost]
        public ActionResult FileUpload(HttpPostedFileBase uploadedFile)
        {
            setFontfamily();
            try
            {
                if (uploadedFile.ContentLength>0)
                {
                    string szFilename = Path.GetFileName(uploadedFile.FileName);
                    string szPath = Path.Combine(Server.MapPath("~/UploadsDirectory"), szFilename);
                    if (!Directory.Exists(szPath))
                    {
                        Directory.CreateDirectory(Server.MapPath("~/UploadsDirectory"));
                    }
                    uploadedFile.SaveAs(szPath);
                }
                ViewBag.UploadSuccess = "Uploaded Successfully";
                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.UploadError = "File Upload Failed!!";
                return View("Index");
            }
        }


        private void BarGen(string barType,string bHeight,string bWidth,string fontFamily,string fSize)
        {
            DataTable dtbBarCode = new DataTable();
            Workbook workbook = new Workbook();
            Worksheet sheet = null;
            List<string> barCodesComplete= null;
            MemoryStream memorystream = null;
            //Bitmap BarcodeBmp = null;
            try
            {
                if (Directory.Exists(Server.MapPath("~/UploadsDirectory")))
                {
                    barCodesComplete = new List<string>();
                    string[] filePaths = Directory.GetFiles(Server.MapPath("~/UploadsDirectory"));
                    foreach (var item in filePaths)
                    {
                        workbook.LoadFromFile(item, false);
                        sheet = workbook.Worksheets[0];
                    }
                    dtbBarCode = sheet.ExportDataTable();
                    Bitmap bCode = null;
                    float fontSize = (float)(Convert.ToInt32(fSize));

                    int iWidth = Convert.ToInt32(bWidth);
                    int iHeigt = Convert.ToInt32(bHeight);

                    if (barType == string.Empty)
                    {
                        barType = "Code39";
                    }
                    if (fontFamily == string.Empty)
                    {
                        fontFamily = "Arial Black";
                    }
                    Font custFont = new Font(new FontFamily(fontFamily), fontSize, FontStyle.Regular, GraphicsUnit.Pixel);

                    //barType.Replace(" ",string.Empty)
                    BarcodeEncoding bChoosenType = (BarcodeEncoding)Enum.Parse(typeof(BarcodeEncoding), barType,true);

                    foreach (DataRow item in dtbBarCode.Rows)
                    {
                        bCode = IronBarCode.BarcodeWriter.CreateBarcode(item.ItemArray[0].ToString(), bChoosenType).ResizeTo(iWidth, iHeigt).AddBarcodeValueTextBelowBarcode(custFont, Color.Black).SetMargins(2).ToBitmap();
                        if (bCode != null)
                        {
                            memorystream = new MemoryStream();
                            bCode.Save(memorystream, ImageFormat.Png);
                            barCodesComplete.Add("data:image/png;base64," + Convert.ToBase64String(memorystream.ToArray()));
                        }
                    }
                    ViewData["BarCodesGenerated"] = barCodesComplete;
                    ViewBag.BarFeeded = "Ready to Print";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMsg = "Incorrect Data for Barcode Type";
            }
            //return barCodesComplete;
        }

    }
}
