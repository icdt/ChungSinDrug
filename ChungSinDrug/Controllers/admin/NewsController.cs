using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using icdtFramework.Extensions;
using icdtFramework.Helpers;
using ChungSinDrug.Models;
using icdtFramework.Models;

namespace ChungSinDrug.Controllers.admin
{
    public class NewsController : Controller
    {

		private int pageSize = 10;

		public ActionResult Index(int page=1)
        {
            int currentPage = page < 1 ? 1 : page;
            var itemList = NewsManager.GetPagedList(page, pageSize);
            var itemModelList = itemList.ToMappedPagedList<News, NewsModel>();
            return View("~/Views/Admin/News/Index.cshtml",itemModelList);
        } 

        public ActionResult Create()
        {
		    var newItem = new NewsModel();
            return View("~/Views/Admin/News/Create.cshtml", newItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel newsModel)
        {
			//if (newsModel.News_StartTime >= newsModel.News_EndTime)
            //{
            //    ModelState.AddModelError(String.Empty, "結束時間不得小於開始時間");
            //    return View(newsModel);
            //}

            if (ModelState.IsValid)
            {
				try
				{
					News news = this.ModelToDomain(newsModel);
					NewsManager.Create(news);
					TempData["SaveOk"] = true;
				}
				catch(Exception)
				{
				    TempData["SaveOk"]  = false;
				}
			}

            return View("~/Views/Admin/News/Create.cshtml", newsModel);
        }

        public ActionResult Edit(string id)
        {
			News theItem = NewsManager.Get(id);
			if (theItem  == null)
            {
			    TempData["EditItemNotFound"] = true;
               return View();
            }
			var theItemModel = this.DomainToModel(theItem);
           
            return View("~/Views/Admin/News/Edit.cshtml", theItemModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsModel newsModel)
        {
			//if (newsModel.News_StartTime >= newsModel.News_EndTime)
            //{
            //    ModelState.AddModelError(String.Empty, "結束時間不得小於開始時間");
            //    return View(newsModel);
            //}

            if (ModelState.IsValid)
            {
				try
				{
					News newsItem = this.ModelToDomain(newsModel);
		     		NewsManager.Update(newsItem);
					 TempData["SaveOk"]  = true;
				}
				catch(Exception)
				{
					TempData["SaveOk"] = false;
				}
		    }
            return View("~/Views/Admin/News/Edit.cshtml",newsModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
			try
			{
			  News  newsItem = NewsManager.Get(id);
			  if(newsItem == null)
			  {
			    TempData["DeleteOk"] = false;
				return RedirectToAction("Index");
			  }
			  NewsManager.Remove(newsItem);
			  TempData["DeleteOk"] = true;
			}
			catch(Exception)
			{
			   TempData["DeleteOk"] = false;
			}
		 
			return RedirectToAction("Index");
		}

		private News ModelToDomain(NewsModel viewModel)
		{
		    News news = new News();
            news = Mapper.Map<NewsModel, News>(viewModel);

            return news;
		}

		private NewsModel DomainToModel(News news)
		{
		  NewsModel viewModel = new NewsModel();
            viewModel = Mapper.Map<News, NewsModel>(news);

            return viewModel;
		}
    }
}
