using ChungSinDrug.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace icdtFramework.Mvc
{
    public static class DropDownListHelper
    {
        /// <summary>
        /// EditorFor: 下拉選單的選項
        /// </summary>
        /// <param name="groupName"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> GetOptions(object groupName, object target)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            if (groupName == null) return items;

            String targetSelected = "";
            if (target != null) targetSelected = target.ToString();
            foreach (var item in SystemParaManager.GetByGroup(groupName.ToString()))
            {
                items.Add(new SelectListItem
                {
                    Text = item.SystemPara_Name,
                    Value = item.SystemPara_Code.ToString(),
                    Selected = targetSelected == item.SystemPara_Code
                });
            }
            return items;
        }

        /// <summary>
        /// Display在列表顯示中文值
        /// </summary>
        /// <param name="group"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetName(string group, string code)
        {
            return SystemParaManager.GetName(group, code);
        }
    }
}