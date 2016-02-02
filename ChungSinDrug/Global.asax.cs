using icdtFramework.Helpers;
using icdtFramework.Mvc;
using LightSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ChungSinDrug
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelMetadataProviders.Current = new ExtendDataAnnotationsModelMetadataProvider();

            //創建預設資料夾
            CreateDirectory();
        }

        #region 創建預設資料夾
        /// <summary>
        /// 創建預設資料夾
        /// </summary>
        private void CreateDirectory()
        {
            //客戶端存放圖片路徑
            var imagepath = Server.MapPath(WebConstants.ClientImagePath);
            //Ckeditor存放圖片路徑
            var imageupload = Server.MapPath(WebConstants.CkeditorImagePath);
            //Ckeditor存放檔案路徑
            var filesupload = Server.MapPath(WebConstants.CkeditorFilesPath);

            if (!Directory.Exists(imagepath))
            {
                Directory.CreateDirectory(imagepath);
            }
            if (!Directory.Exists(imageupload))
            {
                Directory.CreateDirectory(imageupload);
            }
            if (!Directory.Exists(filesupload))
            {
                Directory.CreateDirectory(filesupload);
            }
        }
        #endregion

    }
}
