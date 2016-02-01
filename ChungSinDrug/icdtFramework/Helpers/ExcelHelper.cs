using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

namespace MNES_ELearning.Helpers
{
    public static class ExcelHelper<T> where T : new()
    {
        public static Byte[] OutPutExcel(string sheetName, List<string> sheetTitle, List<T> dataObj)
        {
            #region 表名
            XSSFWorkbook workSheet = new XSSFWorkbook();
            var excelsheet = workSheet.CreateSheet(sheetName);
            #endregion
            #region 表頭
            excelsheet.CreateRow(0);
            for (int i = 0; i < sheetTitle.Count; i++)
            {
                excelsheet.GetRow(0).CreateCell(i).SetCellValue(sheetTitle[i]);
            }
            #endregion
            #region 表身
            for (int i = 1; i < dataObj.Count; i++)
            {
                excelsheet.CreateRow(i);

                foreach (var propertyInfo in dataObj[i].GetType().GetProperties())
                {
                    object objData = propertyInfo.GetValue(dataObj[i], null);
                    excelsheet.GetRow(i).CreateCell(i).SetCellValue(objData.ToString());
                }
            }
            #endregion
            #region 輸出
            MemoryStream MS = new MemoryStream();
            workSheet.Write(MS);
            return MS.ToArray();

            #endregion
        }

        public static Byte[] OutPutExcel2(string sheetName, List<T> dataObj)
        {
            #region 表名
            XSSFWorkbook workSheet = new XSSFWorkbook();
            var excelsheet = workSheet.CreateSheet(sheetName);
            #endregion

            #region 表頭
            excelsheet.CreateRow(0);
            var propertyInfoList = dataObj[0].GetType().GetProperties();
            for (int i = 0; i < propertyInfoList.Count(); i++)
            {
                var tempObj = (DisplayNameAttribute)propertyInfoList[i].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                if (tempObj == null) continue;
                excelsheet.GetRow(0).CreateCell(i).SetCellValue(tempObj.DisplayName);
            }

            #endregion
            #region 表身
            for (int i = 1; i < dataObj.Count; i++)
            {
                excelsheet.CreateRow(i);
                var rowData = dataObj[i - 1].GetType().GetProperties();
                for (int j = 0; j < rowData.Count(); j++)
                {
                    object objData = rowData[j].GetValue(dataObj[i - 1], null);
                    if (objData == null) continue;
                    excelsheet.GetRow(i).CreateCell(j).SetCellValue(objData.ToString());
                }
            }
            #endregion
            #region 輸出
            MemoryStream MS = new MemoryStream();
            workSheet.Write(MS);
            return MS.ToArray();

            #endregion
        }

        public static String InputeExcel(string filePath)
        {
            using (FileStream files = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                #region Excel介面
                IWorkbook workSheet;
                string extension = Path.GetExtension(filePath);
                if (extension.Equals(".xls"))
                {
                    workSheet = new HSSFWorkbook(files);
                }
                else
                {
                    workSheet = new XSSFWorkbook(files);
                }
                ISheet sheet = workSheet.GetSheetAt(0);
                #endregion

                #region 初始化
                List<T> targetObjList = new List<T>();
                Dictionary<int, string> tempDic = new Dictionary<int, string>();
                List<String> titleName = new List<string>();
                #endregion
                
                #region 表頭
                var propertyInfoList = new T().GetType().GetProperties();
                for (int i = 0; i < propertyInfoList.Count(); i++)
                {
                    var tempObj = (DisplayAttribute)propertyInfoList[i].GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();
                    if (tempObj == null) continue;
                    ResourceManager rm = new ResourceManager(tempObj.ResourceType);
                    titleName.Add(rm.GetObject(tempObj.Name).ToString());
                }

                for (int i = 0; i < sheet.GetRow(0).LastCellNum; i++)
                {
                    string excelTitle = sheet.GetRow(0).GetCell(i).StringCellValue;
                    string sameTitleObj = titleName.Where(a => a == excelTitle).FirstOrDefault();
                    if (String.IsNullOrEmpty(sameTitleObj)) continue;
                    tempDic.Add(i, sameTitleObj);
                }
               
                #endregion
                
                #region 表身
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    if (sheet.GetRow(i) != null)
                    {
                        T newObj = new T();
                        var propertyInfoList2 = newObj.GetType().GetProperties();
                        for (int j = 0; j < sheet.GetRow(i).LastCellNum; j++)
                        {
                            String searchTitle;
                            tempDic.TryGetValue(j, out searchTitle);
                            string customerData = sheet.GetRow(i).GetCell(j).StringCellValue;

                            for (int k = 0; k < propertyInfoList2.Count(); k++)
                            {
                                var tempObj = (DisplayNameAttribute)propertyInfoList2[k].GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                                if (tempObj == null) continue;
                                if (tempObj.DisplayName == searchTitle)
                                {
                                    Type type = newObj.GetType();
                                    PropertyInfo propertyInfo = type.GetProperty(propertyInfoList2[k].Name);

                                    propertyInfo.SetValue(newObj, customerData);
                                    // propertyInfoList2[k].SetValue(propertyInfoList2[k], customerData, null);
                                }

                            }
                        }
                        targetObjList.Add(newObj);
                    }
                }
                #endregion
              
                return Newtonsoft.Json.JsonConvert.SerializeObject(targetObjList);
            }
          
        }


    }
}

// excelsheet.GetRow(i).CreateCell(i).SetCellValue();
 //var ff = propertyInfo.GetCustomAttributes(typeof(DisplayNameAttribute), true);