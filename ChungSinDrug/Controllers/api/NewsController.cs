using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using icdtFramework.Extensions;
using icdtFramework.Helpers;
using icdtFramework.Controllers;
using icdtFramework.Configs;
using ChungSinDrug.Models;
using icdtFramework.Models;

namespace ChungSinDrug.Controllers.api
{
    public class NewsController : ApiController
    {
        public IHttpActionResult GetNews()
        {
            var returnList = NewsManager.GetAll();
            return Ok(returnList);
        }

        public IHttpActionResult GetNews(string id)
        {
            var theItem = NewsManager.Get(id);
            if (theItem == null) return BadRequest("Not Found");
            return Ok(theItem);
        }

        public IHttpActionResult PostNews(NewsModel newsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                News news = this.ModelToDomain(newsModel);
                NewsManager.Create(news);
            }
            catch (Exception ex)
            {
                return BadRequest("Error has occured during save: " + ex.Message);
            }
            return Ok();
        }

        public IHttpActionResult PutNews(string id, NewsModel newsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != newsModel.News_Id)
            {
                return BadRequest();
            }

            try
            {
                News newsItem = this.ModelToDomain(newsModel);
                NewsManager.Update(newsItem);
            }
            catch (Exception ex)
            {
                return BadRequest("Error has occured during save: " + ex.Message);
            }

            return Ok();
        }

        public IHttpActionResult DeleteNews(string id)
        {
            News theItem = NewsManager.Get(id);
            if (theItem == null)
            {
                return BadRequest("Not Found");
            }

            try
            {
                NewsManager.Remove(theItem);
            }
            catch (Exception ex)
            {
                return BadRequest("Error has occured when remove item: " + ex.Message);
            }

            return Ok();
        }

        private News ModelToDomain(NewsModel viewModel)
        {
            News news = new News();
            news = AutoMapperConfig.Mapper.Map<NewsModel, News>(viewModel);

            return news;
        }

        private NewsModel DomainToModel(News news)
        {
            NewsModel viewModel = new NewsModel();
            viewModel = AutoMapperConfig.Mapper.Map<News, NewsModel>(news);

            return viewModel;
        }
    }
}