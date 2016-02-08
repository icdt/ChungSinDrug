using icdtFramework.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChungSinDrug.Models
{
    public class icdtTestModel
    {
        [HiddenInput(DisplayValue = false)]
        public string icdtTest_Id { get; set; }

        [Display(Name = "開始時間")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [UIHint("DatePicker")]
        public DateTime icdtTest_DatePicker_StartOfDay { get; set; }

        [Display(Name = "開始時間")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [UIHint("DatePicker")]
        public DateTime icdtTest_DatePicker_EndOfDay { get; set; }

        [Required]
        [UIHint("DateDropDownList")]
        [DataType(DataType.Date)]
        [AgeRange(MinAge = 18, MaxAge = 65, ErrorMessage = "年齡限制為 18 ~ 65 歲.")]
        //[MinAge(18, ErrorMessage = "未滿 18 歲是不行的喔！")]
        //[MaxAge(65, ErrorMessage = "不可以超過 65 歲喔！")]
        [AdditionalMetadata("TaiwanCalendarYear", true)]
        [AdditionalMetadata("YearStart", 1912)]
        [AdditionalMetadata("YearEnd", 2020)]
        [AdditionalMetadata("YearOption", "年")]
        [AdditionalMetadata("MonthOption", "月")]
        [AdditionalMetadata("DayOption", "日")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime icdtTest_DateDropDownList_StartOfDay { get; set; }

        [UIHint("DateDropDownList")]
        [DataType(DataType.Date)]
        //[AgeRange(MinAge = 18, MaxAge = 65, ErrorMessage = "年齡限制為 18 ~ 65 歲.")]
        //[MinAge(18, ErrorMessage = "未滿 18 歲是不行的喔！")]
        //[MaxAge(65, ErrorMessage = "不可以超過 65 歲喔！")]
        [AdditionalMetadata("TaiwanCalendarYear", true)]
        [AdditionalMetadata("YearStart", 1912)]
        [AdditionalMetadata("YearEnd", 2020)]
        [AdditionalMetadata("YearOption", "年")]
        [AdditionalMetadata("MonthOption", "月")]
        [AdditionalMetadata("DayOption", "日")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? icdtTest_DateDropDownList_EndOfDay { get; set; }

        [UIHint("DropDownListTemplate", "", "OptionLabel", "- 請選擇 -", "DropDownListMethodName", "GetOptions", "DropDownListName", "最新消息")]
        public string icdtTest_DropDownList { get; set; }

        [AllowHtml]
        [UIHint("Ckeditor")]
        [DataType(DataType.Html)]
        public string icdtTest_CKEditor { get; set; }

        [UIHint("Uploadify", null, "Path", "icdtTest")]
        public string icdtTest_Image { get; set; }

        [UIHint("ShowCH", null, "Type", "發布")]
        public bool icdtTest_Checkbox { get; set; }

        public DateTime icdtTest_CreateTime { get; set; }
        public string icdtTest_CreatorId { get; set; }
        public string icdtTest_CreatorUserName { get; set; }

        public DateTime icdtTest_UpdateTime { get; set; }
        public string icdtTest_UpdaterId { get; set; }
        public string icdtTest_UpdaterUserName { get; set; }

        public bool icdtTest_DelLock { get; set; }

        public icdtTestModel()
        {
            this.icdtTest_Id = Guid.NewGuid().ToString();
            this.icdtTest_DatePicker_StartOfDay = DateTime.Now;
            this.icdtTest_DatePicker_EndOfDay = DateTime.Now;
            this.icdtTest_DateDropDownList_StartOfDay = DateTime.Now;
            this.icdtTest_DateDropDownList_EndOfDay = null;
            this.icdtTest_DropDownList = "";
            this.icdtTest_Checkbox = false;
            this.icdtTest_CKEditor = "";
            this.icdtTest_CreatorId = "";
            this.icdtTest_CreatorUserName = "";
            this.icdtTest_CreateTime = DateTime.Now;
            this.icdtTest_UpdaterId = "";
            this.icdtTest_UpdaterUserName = "";
            this.icdtTest_UpdateTime = DateTime.Now;
        }
        
    }
}