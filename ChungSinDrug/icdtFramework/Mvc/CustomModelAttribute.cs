using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.CustomViewTemplate
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotShowAttribute : Attribute
    {
        public NotShowAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotEditableAttribute : Attribute
    {
        public NotEditableAttribute() { }
    }

    public static class T4Helpers
    {
        public static bool NotShow(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (NotShowAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(NotShowAttribute));
                return richText != null;
            }

            return isRichText;
        }

        public static bool NotEditable(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (NotEditableAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(NotEditableAttribute));
                return richText != null;
            }

            return isRichText;
        }
    }
}