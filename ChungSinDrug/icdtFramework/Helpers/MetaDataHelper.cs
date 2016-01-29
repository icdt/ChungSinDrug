using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace icdtFramework.Helpers
{
    //http://stackoverflow.com/questions/5474460/get-displayname-attribute-of-a-property-in-strongly-typed-way
    public static class MetaDataHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="fieldName">var path="~/AAA/BBB";</param>
        /// <returns></returns>
        public static string GetDisplayName(Type dataType, string fieldName)
        {
            // First look into attributes on a type and it's parents
            DisplayNameAttribute attr;
            attr = (DisplayNameAttribute)dataType.GetProperty(fieldName).GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();

            // Look for [MetadataType] attribute in type hierarchy
            // http://stackoverflow.com/questions/1910532/attribute-isdefined-doesnt-see-attributes-applied-with-metadatatype-class
            if (attr == null)
            {
                MetadataTypeAttribute metadataType = (MetadataTypeAttribute)dataType.GetCustomAttributes(typeof(MetadataTypeAttribute), true).FirstOrDefault();
                if (metadataType != null)
                {
                    var property = metadataType.MetadataClassType.GetProperty(fieldName);
                    if (property != null)
                    {
                        attr = (DisplayNameAttribute)property.GetCustomAttributes(typeof(DisplayNameAttribute), true).SingleOrDefault();
                    }
                }
            }
            return (attr != null) ? attr.DisplayName : String.Empty;
        }
    }
}