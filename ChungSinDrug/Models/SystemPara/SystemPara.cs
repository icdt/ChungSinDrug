using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChungSinDrug.Models
{
    public class SystemPara
    {
        [Key]
        public string SystemPara_Id { get; set; }

        public string SystemPara_ParentId { get; set; }

        public string SystemPara_Name { get; set; }

        public string SystemPara_Code { get; set; }

        public int SystemPara_Sort { get; set; }

        public string SystemPara_Group { get; set; }

        public bool SystemPara_DelLock { get; set; }

        public DateTime SystemPara_CreateTime { get; set; }

        public string SystemPara_CreatorId { get; set; }

        public string SystemPara_CreatorUserName { get; set; }

        public DateTime SystemPara_UpdateTime { get; set; }

        public string SystemPara_UpdaterId { get; set; }

        public string SystemPara_UpdaterUserName { get; set; }

       
    }
}