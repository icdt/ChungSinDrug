using ChungSinDrug;
using icdtFramework.Configs;
using icdtFramework.Helpers;
using icdtFramework.Models;
using icdtFramework.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace icdtFramework
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

            // 使用icdt建立的Data Annotation Provider
            ModelMetadataProviders.Current = new ExtendDataAnnotationsModelMetadataProvider();

            // 初始化使用者快取
            UserAccountManager.Initialize();

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
