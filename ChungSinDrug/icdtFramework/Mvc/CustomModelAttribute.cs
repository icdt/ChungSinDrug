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

    [AttributeUsage(AttributeTargets.Property)]
    public class T4StartOfDayAttribute : Attribute
    {
        public T4StartOfDayAttribute() { }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class T4EndOfDayAttribute : Attribute
    {
        public T4EndOfDayAttribute() { }
    }

    public static class T4Helpers
    {
        private const string MODEL_NAME_SPACE = "ChungSinDrug.Models.";

        #region View使用, 不能加NameSpace
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
        #endregion

        #region ModelManager使用, 需加NameSpace
        public static bool T4IsStartOfDay(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(MODEL_NAME_SPACE + viewDataTypeName);

            if (typeModel != null)
            {
                richText = (T4StartOfDayAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(T4StartOfDayAttribute));
                return richText != null;
            }

            return isRichText;
        }

        public static bool T4IsEndOfDay(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(MODEL_NAME_SPACE + viewDataTypeName);

            if (typeModel != null)
            {
                richText = (T4EndOfDayAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(T4EndOfDayAttribute));
                return richText != null;
            }

            return isRichText;
        }
        #endregion
    }
}