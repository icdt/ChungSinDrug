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
        public static MapperConfiguration myConfiguration;
        public static IMapper Mapper;

        public static void Configure()
        {
            myConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<icdtTest, icdtTestModel>();
                cfg.CreateMap<icdtTestModel, icdtTest>();

            });
            Mapper = myConfiguration.CreateMapper();
        }
    }

    //public class DomainToModel : Profile
    //{
    //    protected override void Configure()
    //    {
    //        var config = new MapperConfiguration(cfg => {
    //            cfg.CreateMap<News, NewsModel>();
    //            cfg.CreateMap<icdtTest, icdtTestModel>();
    //        });
    //        //Mapper.CreateMap<News, NewsModel>();
    //        //Mapper.CreateMap<icdtTest, icdtTestModel>();
    //    }
    //}

    //public class ModelToDomain : Profile
    //{
    //    protected override void Configure()
    //    {
    //        var config = new MapperConfiguration(cfg => {
    //            cfg.CreateMap<NewsModel, News>();
    //            cfg.CreateMap<icdtTestModel, icdtTest>();
    //        });
    //        //Mapper.CreateMap<NewsModel, News>();
    //        //Mapper.CreateMap<icdtTestModel, icdtTest>();
    //    }
    //}


}