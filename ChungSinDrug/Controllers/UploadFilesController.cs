using icdtFramework.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChungSinDrug.Controllers
{
    public class UploadController : Controller
    {

        [HttpPost]
        public ActionResult Images(HttpPostedFileBase file, string category)
        {
            string folderPrefix = Guid.NewGuid().ToString();
            var path = "/Uploads/" + category + "/" + folderPrefix + "/" + file.FileName;

            try
            {
                // FileHelper
                //FileHelper.SaveFile(file, path);
                file.SaveAs(Server.MapPath("~" + path));
                return Content(path);
            }
            catch (Exception ex)
            {
                return Content("Fail to save files");
            }

        }
    }
}