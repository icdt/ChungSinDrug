using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChungSinDrug.Models
{
    public static class SystemParaManager
    {
        public static List<SystemPara> GetByGroup(string groupName)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                return db.SystemParas.Where(a => a.SystemPara_DelLock == false && a.SystemPara_Group == groupName).ToList();
            }
        }
    }
}