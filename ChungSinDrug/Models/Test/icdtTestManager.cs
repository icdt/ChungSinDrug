using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using icdtFramework.Helpers;
using icdtFramework.Models;

namespace ChungSinDrug.Models
{
    public static class icdtTestManager
    {
        private static List<icdtTest> _icdtTestCache = new List<icdtTest>();
        private static object _icdttestQueueLock = new Object();

        #region 初始化
        //初始化
        //public static void Initial()
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var query = db.icdtTests.AsQueryable();
        //        query = query.Where(a => a.icdtTest_DelLock == false);

        //        _icdtTestCache = query.ToList();
        //    }
        //}
        #endregion

        #region 基本操作 (db & cache)
        //取得所有記錄
        public static List<icdtTest> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.icdtTests.Where(a => a.icdtTest_DelLock == false).ToList();
            }
        }

        //分頁
        public static IPagedList<icdtTest> GetPagedList(int pageNumber, int pageSize)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.icdtTests.Where(a => a.icdtTest_DelLock == false)
                .OrderByDescending(a => a.icdtTest_CreateTime)
                .ToPagedList(pageNumber, pageSize);
            }
        }

        //透過Id取得記錄
        public static icdtTest Get(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.icdtTests.FirstOrDefault(a => a.icdtTest_Id == id);
            }
        }

        //新增單一記錄
        public static void Create(icdtTest icdttest)
        {
            Create(new List<icdtTest>() { icdttest });
        }

        //新增多筆記錄
        public static void Create(List<icdtTest> icdttests)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                foreach (icdtTest item in icdttests)
                {
                    item.icdtTest_DatePicker_StartOfDay = DateTimeHelper.StartOfDay(item.icdtTest_DatePicker_StartOfDay);
                    item.icdtTest_DatePicker_EndOfDay = DateTimeHelper.EndOfDay(item.icdtTest_DatePicker_EndOfDay);
                    item.icdtTest_DateDropDownList_StartOfDay = DateTimeHelper.StartOfDay(item.icdtTest_DateDropDownList_StartOfDay);
                    item.icdtTest_DateDropDownList_EndOfDay = DateTimeHelper.EndOfDay(item.icdtTest_DateDropDownList_EndOfDay);
                }
                db.icdtTests.AddRange(icdttests);
                db.SaveChanges();
            }
        }

        //更新一筆記錄
        public static void Update(icdtTest icdttests)
        {
            Update(new List<icdtTest>() { icdttests });
        }

        //更新多筆記錄
        public static void Update(List<icdtTest> icdttests)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var objIDs = icdttests.Select(a => a.icdtTest_Id).ToList();
                var objInDB = db.icdtTests.Where(a => objIDs.Contains(a.icdtTest_Id)).ToList();

                foreach (icdtTest item in objInDB)
                {
                    var theNewFromOutside = icdttests.FirstOrDefault(a => a.icdtTest_Id == item.icdtTest_Id);
                    item.icdtTest_Id = theNewFromOutside.icdtTest_Id;
                    item.icdtTest_DatePicker_StartOfDay = DateTimeHelper.StartOfDay(theNewFromOutside.icdtTest_DatePicker_StartOfDay);
                    item.icdtTest_DatePicker_EndOfDay = DateTimeHelper.EndOfDay(theNewFromOutside.icdtTest_DatePicker_EndOfDay);
                    item.icdtTest_DateDropDownList_StartOfDay = DateTimeHelper.StartOfDay(theNewFromOutside.icdtTest_DateDropDownList_StartOfDay);
                    item.icdtTest_DateDropDownList_EndOfDay = DateTimeHelper.EndOfDay(theNewFromOutside.icdtTest_DateDropDownList_EndOfDay);
                    item.icdtTest_DropDownList = theNewFromOutside.icdtTest_DropDownList;
                    item.icdtTest_CKEditor = theNewFromOutside.icdtTest_CKEditor;
                    item.icdtTest_Image = theNewFromOutside.icdtTest_Image;
                    item.icdtTest_Checkbox = theNewFromOutside.icdtTest_Checkbox;
                    item.icdtTest_CreateTime = theNewFromOutside.icdtTest_CreateTime;
                    item.icdtTest_CreatorId = theNewFromOutside.icdtTest_CreatorId;
                    item.icdtTest_CreatorUserName = theNewFromOutside.icdtTest_CreatorUserName;
                    item.icdtTest_UpdateTime = theNewFromOutside.icdtTest_UpdateTime;
                    item.icdtTest_UpdaterId = theNewFromOutside.icdtTest_UpdaterId;
                    item.icdtTest_UpdaterUserName = theNewFromOutside.icdtTest_UpdaterUserName;
                    item.icdtTest_DelLock = theNewFromOutside.icdtTest_DelLock;
                }

                lock (_icdttestQueueLock)
                {
                    db.SaveChanges();
                }
            }
        }

        //刪除一筆記錄
        public static void Remove(icdtTest icdttest)
        {
            Remove(new List<icdtTest>() { icdttest });
        }

        //刪除多筆記錄
        public static void Remove(List<icdtTest> icdttests)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var objIDs = icdttests.Select(a => a.icdtTest_Id).ToList();
                var objInDB = db.icdtTests.Where(a => objIDs.Contains(a.icdtTest_Id)).ToList();

                foreach (var item in objInDB)
                {
                    item.icdtTest_DelLock = true;
                }

                lock (_icdttestQueueLock)
                {
                    db.SaveChanges();
                }
            }
        }
        #endregion

        #region 進階查詢

        #endregion
    }
}
