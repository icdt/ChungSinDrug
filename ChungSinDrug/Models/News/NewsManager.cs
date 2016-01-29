using System;
using System.Collections.Generic;
using System.Linq;

namespace ChungSinDrug.Models
{
    public class NewsManager
    {
        private static List<News> _NewsCache = new List<News>();
        private static object _newsQueueLock = new Object();

        #region 初始化
        //初始化
        //public static void Initial()
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var query = db.News.AsQueryable();
        //        query = query.Where(a => a.News_DelLock == false);

        //        _NewsCache = query.ToList();
        //    }
        //}
        #endregion

        #region 基本操作 (db & cache)
        //取得所有記錄
        public static IQueryable<News> GetAll()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.News.Where(a => a.News_DelLock == false);
            }
        }

        //分頁
        //public static IPagedList<News> GetPagedList(int pageNumber, int pageSize)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        return db.News.OrderByDescending(a => a.News_CreateTime).ToPagedList(pageNumber, pageSize);

        //    }
        //}

        //透過Id取得記錄
        public static News Get(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.News.FirstOrDefault(a => a.News_Id == id);
            }
        }

        //新增單一記錄
        public static void Create(News news)
        {
            Create(new List<News>() { news });
        }

        //新增多筆記錄
        public static void Create(List<News> newss)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.News.AddRange(newss);
                db.SaveChanges();
            }

        }

        //更新一筆記錄
        public static void Update(News newss)
        {
            Update(new List<News>() { newss });
        }

        //更新多筆記錄
        public static void Update(List<News> newss)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var objIDs = newss.Select(a => a.News_Id).ToList();
                var objInDB = db.News.Where(a => objIDs.Contains(a.News_Id)).ToList();

                foreach (News item in objInDB)
                {
                    var theNewFromOutside = newss.FirstOrDefault(a => a.News_Id == item.News_Id);

                    item.News_CoverImage = theNewFromOutside.News_CoverImage;
                    item.News_Title = theNewFromOutside.News_Title;
                    item.News_Content = theNewFromOutside.News_Content;
                    item.News_IsPublish = theNewFromOutside.News_IsPublish;
                    item.News_IsTop = theNewFromOutside.News_IsTop;

                    item.News_UpdateTime = theNewFromOutside.News_UpdateTime;
                    item.News_UpdaterId = theNewFromOutside.News_UpdaterId;
                    item.News_UpdaterUserName = theNewFromOutside.News_UpdaterUserName;

                }

                lock (_newsQueueLock)
                {
                    db.SaveChanges();
                }
            }
        }

        //刪除一筆記錄
        public static void Remove(News news)
        {
            Remove(new List<News>() { news });
        }

        //刪除多筆記錄
        public static void Remove(List<News> newss)
        {
            //更新資料庫
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var objIDs = newss.Select(a => a.News_Id).ToList();
                var objInDB = db.News.Where(a => objIDs.Contains(a.News_Id)).ToList();

                foreach (var item in objInDB)
                {
                    item.News_DelLock = true;
                }

                lock (_newsQueueLock)
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