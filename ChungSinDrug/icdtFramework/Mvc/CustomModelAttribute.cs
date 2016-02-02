using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.CustomViewTemplate
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NotListShowAttribute : Attribute
    {
        public NotListShowAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotFormShowAttribute : Attribute
    {
        public NotFormShowAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotEditableAttribute : Attribute
    {
        public NotEditableAttribute() { }
    }

    public static class T4Helpers
    {
        public static bool NotListShow(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (NotListShowAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(NotListShowAttribute));
                return richText != null;
            }

            return isRichText;
        }

        public static bool NotFormShow(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (NotFormShowAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(NotFormShowAttribute));
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