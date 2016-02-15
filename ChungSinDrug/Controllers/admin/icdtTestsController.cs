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
using icdtFramework.Controllers;
using icdtFramework.Configs;
using ChungSinDrug.Models;
using icdtFramework.Models;

namespace ChungSinDrug.Controllers.admin
{
    public class icdtTestsController : Controller
    {

		private int pageSize = 10;

		public ActionResult Index(int page=1)
        {
            int currentPage = page < 1 ? 1 : page;
            var itemList = icdtTestManager.GetPagedList(page, pageSize);
            var itemModelList = itemList.ToMappedPagedList<icdtTest, icdtTestModel>();
            return View("~/Views/Admin/icdtTests/Index.cshtml",itemModelList);
        } 

        public ActionResult Create()
        {
		    var newItem = new icdtTestModel();
            return View("~/Views/Admin/icdtTests/Create.cshtml", newItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(icdtTestModel icdtTestModel)
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
					icdtTest icdtTest = this.ModelToDomain(icdtTestModel);
					icdtTestManager.Create(icdtTest);
					TempData["SaveOk"] = true;
				}
				catch(Exception)
				{
				    TempData["SaveOk"]  = false;
				}
			}

            return View("~/Views/Admin/icdtTests/Create.cshtml", icdtTestModel);
        }

        public ActionResult Edit(string id)
        {
			icdtTest theItem = icdtTestManager.Get(id);
			if (theItem  == null)
            {
			    TempData["EditItemNotFound"] = true;
               return View();
            }
			var theItemModel = this.DomainToModel(theItem);
           
            return View("~/Views/Admin/icdtTests/Edit.cshtml", theItemModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(icdtTestModel icdtTestModel)
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
					icdtTest icdtTestItem = this.ModelToDomain(icdtTestModel);
		     		icdtTestManager.Update(icdtTestItem);
					 TempData["SaveOk"]  = true;
				}
				catch(Exception)
				{
					TempData["SaveOk"] = false;
				}
		    }
            return View("~/Views/Admin/icdtTests/Edit.cshtml",icdtTestModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
			try
			{
			  icdtTest  theItem = icdtTestManager.Get(id);
			  if(theItem == null)
			  {
			    TempData["DeleteOk"] = false;
				return RedirectToAction("Index");
			  }
			  icdtTestManager.Remove(theItem);
			  TempData["DeleteOk"] = true;
			}
			catch(Exception)
			{
			   TempData["DeleteOk"] = false;
			}
		 
			return RedirectToAction("Index");
		}

		private icdtTest ModelToDomain(icdtTestModel viewModel)
		{
		    icdtTest icdtTest = new icdtTest();
            icdtTest = AutoMapperConfig.Mapper.Map<icdtTestModel, icdtTest>(viewModel);

            return icdtTest;
		}

		private icdtTestModel DomainToModel(icdtTest icdtTest)
		{
		  icdtTestModel viewModel = new icdtTestModel();
            viewModel = AutoMapperConfig.Mapper.Map<icdtTest, icdtTestModel>(icdtTest);

            return viewModel;
		}
    }
}
