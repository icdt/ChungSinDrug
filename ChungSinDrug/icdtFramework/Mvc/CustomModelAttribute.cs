using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.CustomViewTemplate
{
    [AttributeUsage(AttributeTargets.Property)]
    public class T4NotListShowAttribute : Attribute
    {
        public T4NotListShowAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class T4NotFormShowAttribute : Attribute
    {
        public T4NotFormShowAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class T4NotEditableAttribute : Attribute
    {
        public T4NotEditableAttribute() { }
    }

    public static class T4Helpers
    {
        public static bool T4NotListShow(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (T4NotListShowAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(T4NotListShowAttribute));
                return richText != null;
            }

            return isRichText;
        }

        public static bool T4NotFormShow(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (T4NotFormShowAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(T4NotFormShowAttribute));
                return richText != null;
            }

            return isRichText;
        }

        public static bool T4NotEditable(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (T4NotEditableAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(T4NotEditableAttribute));
                return richText != null;
            }

            return isRichText;
        }
    }
}