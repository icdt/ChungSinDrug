using AutoMapper;
using ChungSinDrug.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.Configs
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToModel>();
                x.AddProfile<ModelToDomain>();
            });
        }
    }

    public class DomainToModel : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<News, NewsModel>();
        }
    }

    public class ModelToDomain : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<NewsModel, News>();
        }
    }


}