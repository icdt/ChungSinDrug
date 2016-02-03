using icdtFramework.Helpers;
using icdtFramework.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace icdtFramework.Controllers
{
    public class ImageUploadController : MvcBaseController
    {
        /// <summary>
        /// 圖片上傳
        /// </summary>
        /// <param name="path">儲存類別資料夾 path=News/guid </param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FileUpload(string path)
        {
            //var images = new List<string>();
            var httpRequest = System.Web.HttpContext.Current.Request;
            var firstpath = WebConstants.ClientImagePath + path;
            string filepath = Server.MapPath(firstpath);
            string newpath = string.Empty;

            try
            {
                if (Directory.Exists(filepath) == false)
                {
                    Directory.CreateDirectory(filepath);
                }
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, Server.UrlEncode("路徑不存在!!"));
            }

            foreach (string file in httpRequest.Files)
            {
                HttpPostedFileBase uploadFile = Request.Files[file] as HttpPostedFileBase;

                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    newpath = filepath + "/" + uploadFile.FileName;

                    #region 限制寬高
                    double finalwidth = 10;
                    double finalheight = 10;
                    #endregion

                    if (ImageHelper.OptimizeNResize(uploadFile, newpath, (int)finalwidth, (int)finalheight))
                    {
                        newpath = firstpath.Replace("~", "") + "/" + uploadFile.FileName;
                        //images.Add(newpath);
                    }
                    uploadFile.InputStream.Dispose();
                }
            }

            //return Content(JsonConvert.SerializeObject(images));
            return Content(newpath);
        }

        /// <summary>
        /// 編輯器圖片上傳
        /// </summary>
        /// <param name="upload"></param>
        /// <param name="CKEditorFuncNum"></param>
        /// <param name="CKEditor"></param>
        /// <param name="langCode"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CkeditorImageUpload(HttpPostedFileBase upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            string result = "";
            if (upload != null && upload.ContentLength > 0)
            {
                //儲存圖片至Server
                upload.SaveAs(Server.MapPath(WebConstants.CkeditorImagePath + upload.FileName));

                var imageUrl = Url.Content(WebConstants.CkeditorImagePath + upload.FileName);
                var vMessage = string.Empty;

                result = @"<html><body><script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + imageUrl + "\", \"" + vMessage + "\");</script></body></html>";

            }

            return Content(result);
        }

    }
}