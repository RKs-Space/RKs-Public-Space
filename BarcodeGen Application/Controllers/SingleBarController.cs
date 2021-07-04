using IronBarCode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BarGen.Controllers
{
    public class SingleBarController : Controller
    {

        private void setBarcodeTypes()
        {
            List<BarcodeEncoding> codeTypes = Enum.GetValues(typeof(BarcodeEncoding)).Cast<BarcodeEncoding>().ToList();
            List<string> stringBar = (from o in codeTypes select o.ToString()).ToList();
            stringBar.Select(m => new SelectListItem { Text = m, Value = m });
            ViewBag.barTypes = stringBar;
        }
        // GET: SingleBar
        public ActionResult SingleBarView()
        {
            setBarcodeTypes();
            return View();
        }

        [HttpPost]
        public ActionResult SingleBarView(FormCollection fc)
        {
            setBarcodeTypes();
            string value = fc["BarType"];
            string product = fc["Product"];
            MemoryStream memorystream = new MemoryStream();
            Bitmap BarcodeBmp = null;

            try
            {
                Font custFont = new Font(new FontFamily("Arial Black"), 15f, FontStyle.Regular, GraphicsUnit.Pixel);
                BarcodeEncoding bChoosenType = (BarcodeEncoding)Enum.Parse(typeof(BarcodeEncoding), value, true);

                BarcodeBmp = IronBarCode.BarcodeWriter.CreateBarcode(product, bChoosenType).ResizeTo(300, 100).AddBarcodeValueTextBelowBarcode(custFont, Color.Black).SetMargins(5).ToBitmap();
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(product))
                {
                    BarcodeBmp.Save(memorystream, ImageFormat.Png);
                    ViewBag.BarcodeImage = "data:image/png;base64," + Convert.ToBase64String(memorystream.ToArray());
                }
            }
            catch (Exception ex)
            {
                ViewBag.ExceptionMsg = "Incorrect Data for Barcode Type";
            }
            
            return View("SingleBarView");
        }
    }
}