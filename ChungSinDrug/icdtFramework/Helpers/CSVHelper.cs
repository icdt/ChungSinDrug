using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MNES_ELearning.Helpers
{
    public static class CSVHelper<T> where T : new()
    {
        public static Byte[] OutPutCSV(List<T> exportData)
        {
            System.Text.StringBuilder csv = new System.Text.StringBuilder("");
            #region 表頭
            var propertyInfoList = exportData[0].GetType().GetProperties();
            for (int i = 0; i < propertyInfoList.Count(); i++)
            {
                var tempObj = (DisplayNameAttribute)propertyInfoList[i].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                if (tempObj == null) continue;
                csv.Append(tempObj.DisplayName + ",");
            }
            #endregion

            #region 表身
            for (int i = 1; i < exportData.Count; i++)
            {
                csv.Append("\r\n");
                var rowData = exportData[i - 1].GetType().GetProperties();
                for (int j = 0; j < rowData.Count(); j++)
                {
                    object objData = rowData[j].GetValue(exportData[i - 1], null);
                    if (objData == null) continue;
                    csv.Append(objData + ",");
                }
            }
            #endregion
            return System.Text.Encoding.Default.GetBytes(csv.ToString());
        }


        public static List<T> InPuteCSV(HttpPostedFileBase file)
        {
            List<T> targetObjList = new List<T>();
            Dictionary<int, string> tempDic = new Dictionary<int, string>();
            List<String> titleName = new List<string>();
            StreamReader streamReader = new System.IO.StreamReader(file.InputStream, System.Text.Encoding.Default);
            string UploadOwnersString = streamReader.ReadToEnd();
            UploadOwnersString = UploadOwnersString.Replace(" ", "").Replace("\"", "");
            streamReader.Dispose();
            string[] dataArray = UploadOwnersString.Split(new string[] { "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            #region 取出欄位
            var propertyInfoList = new T().GetType().GetProperties();
            for (int i = 0; i < propertyInfoList.Count(); i++)
            {
                var tempObj = (DisplayNameAttribute)propertyInfoList[i].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                if (tempObj == null) continue;
                titleName.Add(tempObj.ToString());
            }

            var titleList = dataArray[0].Split(',');

            for (int i = 0; i < titleList.Count(); i++)
            {
                tempDic.Add(i, titleList[i]);
            }
            #endregion


            for (int i = 1; i < dataArray.Count(); i++)
            {
                string[] SourceProductValue = dataArray[i].Split(',');

                T newObj = new T();
                var propertyInfoList2 = newObj.GetType().GetProperties();
                for (int j = 0; j < SourceProductValue.Count(); j++)
                {
                    String searchTitle;
                    tempDic.TryGetValue(j, out searchTitle);
                    string customerData = SourceProductValue[j];

                    for (int k = 0; k < propertyInfoList2.Count(); k++)
                    {
                        var tempObj = (DisplayNameAttribute)propertyInfoList2[k].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                        if (tempObj == null) continue;
                        if (tempObj.DisplayName == searchTitle)
                        {
                            PropertyInfo propertyInfo = newObj.GetType().GetProperty(propertyInfoList2[k].Name);
                            propertyInfo.SetValue(newObj, customerData, null);
                        }

                    }
                }
                targetObjList.Add(newObj);
            }
            return targetObjList;
        }


        public static List<T> InPuteCSV2(String filePath)
        {
            List<T> targetObjList = new List<T>();
            Dictionary<int, string> tempDic = new Dictionary<int, string>();
            List<String> titleName = new List<string>();
            StreamReader streamReader = new System.IO.StreamReader(filePath, System.Text.Encoding.Default);
            string UploadOwnersString = streamReader.ReadToEnd();
            UploadOwnersString = UploadOwnersString.Replace(" ", "").Replace("\"", "");
            streamReader.Dispose();
            string[] dataArray = UploadOwnersString.Split(new string[] { "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            #region 取出欄位
            var propertyInfoList = new T().GetType().GetProperties();
            for (int i = 0; i < propertyInfoList.Count(); i++)
            {
                var tempObj = (DisplayNameAttribute)propertyInfoList[i].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                if (tempObj == null) continue;
                titleName.Add(tempObj.ToString());
            }

            var titleList = dataArray[0].Split(',');

            for (int i = 0; i < titleList.Count(); i++)
            {
                tempDic.Add(i, titleList[i]);
            }
            #endregion


            for (int i = 1; i < dataArray.Count(); i++)
            {
                string[] SourceProductValue = dataArray[i].Split(',');

                T newObj = new T();
                var propertyInfoList2 = newObj.GetType().GetProperties();
                for (int j = 0; j < SourceProductValue.Count(); j++)
                {
                    String searchTitle;
                    tempDic.TryGetValue(j, out searchTitle);
                    string customerData = SourceProductValue[j];

                    for (int k = 0; k < propertyInfoList2.Count(); k++)
                    {
                        var tempObj = (DisplayNameAttribute)propertyInfoList2[k].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                        if (tempObj == null) continue;
                        if (tempObj.DisplayName == searchTitle)
                        {
                            PropertyInfo propertyInfo = newObj.GetType().GetProperty(propertyInfoList2[k].Name);
                            propertyInfo.SetValue(newObj, customerData, null);
                        }

                    }
                }
                targetObjList.Add(newObj);
            }
            return targetObjList;



        }
    }
}