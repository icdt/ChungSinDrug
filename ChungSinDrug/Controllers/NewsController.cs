using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ChungSinDrug.Models;

namespace ChungSinDrug.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
		    var returnList = NewsManager.GetAll();
            return View(returnList);
        } 

        public ActionResult Create()
        {
		    var newItem = new NewsModel();
            return View(newItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewsModel newsModel)
        {
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

            return View(newsModel);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                TempData["EditItemNotFound"] = true;
                return RedirectToAction("Index");
            }
			News theItem = NewsManager.Get(id);
			if (theItem  == null)
            {
			    TempData["EditItemNotFound"] = true;
                return RedirectToAction("Index");
            }
			var theItemModel = this.DomainToModel(theItem);
           
            return View(theItemModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(NewsModel newsModel)
        {
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
            return View(newsModel);
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
			    TempData["SaveOk"] = false;
				return RedirectToAction("Index");
			  }
			  NewsManager.Remove(newsItem);
			  TempData["SaveOk"] = true;
			}
			catch(Exception)
			{
			   TempData["SaveOk"] = false;
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
