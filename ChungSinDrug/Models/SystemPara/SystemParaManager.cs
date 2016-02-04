using icdtFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace icdtFramework.Models
{
    public static class SystemParaManager
    {
        public static List<SystemPara> GetByGroup(string groupName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.SystemParas.Where(a => 
                    a.SystemPara_DelLock == false && a.SystemPara_Group == groupName)
                    .OrderBy(a => a.SystemPara_Sort)
                    .ToList();
            }
        }

        public static string GetName(string group, string code)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var systemPara = db.SystemParas.FirstOrDefault(a => a.SystemPara_Group == group && a.SystemPara_Code == code);
                if (systemPara != null)
                {
                    return systemPara.SystemPara_Name;
                }
                return "未指定";
            }
        }
    }
}