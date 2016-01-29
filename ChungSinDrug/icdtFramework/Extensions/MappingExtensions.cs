using AutoMapper;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChungSinDrug.icdtFramework.Extensions
{
    public static class MappingExtensions
    {
        /// <summary>
        /// 用AutoMapper 轉換 IPagedList 的型別
        /// http://stackoverflow.com/questions/2070850/can-automapper-map-a-paged-list
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IPagedList<TDestination> ToMappedPagedList<TSource, TDestination>(this IPagedList<TSource> list)
        {
            IEnumerable<TDestination> sourceList = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(list);
            IPagedList<TDestination> pagedResult = new StaticPagedList<TDestination>(sourceList, list.GetMetaData());
            return pagedResult;

        }

    }
}