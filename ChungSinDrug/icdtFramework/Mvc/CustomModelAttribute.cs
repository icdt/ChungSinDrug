using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.CustomViewTemplate
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RichTextAttribute : Attribute
    {
        public RichTextAttribute() { }
    }

    public static class T4Helpers
    {
        public static bool IsRichText(string viewDataTypeName, string propertyName)
        {
            bool isRichText = false;
            Attribute richText = null;
            Type typeModel = Type.GetType(viewDataTypeName);

            if (typeModel != null)
            {
                richText = (RichTextAttribute)Attribute.GetCustomAttribute(typeModel.GetProperty(propertyName), typeof(RichTextAttribute));
                return richText != null;
            }

            return isRichText;
        }
    }
}