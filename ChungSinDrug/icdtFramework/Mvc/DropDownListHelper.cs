﻿using ChungSinDrug.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace icdtFramework.Mvc
{
    public static class DropDownListHelper
    {
        public static IEnumerable<SelectListItem> CategoryList(object groupName, object target)
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
                    Value = item.SystemPara_Id.ToString(),
                    Selected = targetSelected == item.SystemPara_Id
                });
            }
            return items;
        }
    }
}