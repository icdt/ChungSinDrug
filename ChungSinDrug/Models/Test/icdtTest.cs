using icdtFramework.CustomViewTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChungSinDrug.Models
{
    public class icdtTest
    {
        [Key]
        public string icdtTest_Id { get; set; }

        [T4StartOfDay]
        public DateTime icdtTest_DatePicker_StartOfDay { get; set; }

        [T4EndOfDay]
        public DateTime icdtTest_DatePicker_EndOfDay { get; set; }

        [T4StartOfDay]
        public DateTime icdtTest_DateDropDownList_StartOfDay { get; set; }

        [T4EndOfDay]
        public DateTime icdtTest_DateDropDownList_EndOfDay { get; set; }


        public string icdtTest_DropDownList { get; set; }

        [T4NotListShow]
        public string icdtTest_CKEditor { get; set; }

        public string icdtTest_Image { get; set; }

        public bool icdtTest_Checkbox { get; set; }

        [T4NotEditable]
        [T4NotListShow]
        public DateTime icdtTest_CreateTime { get; set; }

        [T4NotListShow]
        [T4NotFormShow]
        public string icdtTest_CreatorId { get; set; }

        [T4NotListShow]
        [T4NotFormShow]
        public string icdtTest_CreatorUserName { get; set; }

        [T4NotEditable]
        [T4NotListShow]
        public DateTime icdtTest_UpdateTime { get; set; }

        [T4NotListShow]
        [T4NotFormShow]
        public string icdtTest_UpdaterId { get; set; }

        [T4NotListShow]
        [T4NotFormShow]
        public string icdtTest_UpdaterUserName { get; set; }

        [T4NotListShow]
        [T4NotFormShow]
        public bool icdtTest_DelLock { get; set; }

    }

}