using icdtFramework.CustomViewTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChungSinDrug.Models
{
    public class NewsModel
    {
        [HiddenInput(DisplayValue =false)]
        public string News_Id { get; set; }

        [Display(Name = "標題")]
        public string News_Title { get; set; }

        [Display(Name = "開始時間")]
        [UIHint("DatePicker")]
        public string News_StartTime { get; set; }

        [Display(Name = "結束時間")]
        [UIHint("DatePicker")]
        public string News_EndTime { get; set; }

        [AllowHtml]
        [Display(Name = "內文")]
        [UIHint("Ckeditor")]
        [DataType(DataType.Html)]
        public string News_Content { get; set; }

        [Display(Name = "封面圖片")]
        [UIHint("Uploadify", null, "Path", "News")]
        public string News_CoverImage { get; set; }
        [Required(ErrorMessage = "Category 為必填")]
        [UIHint("DropDownListTemplate", "", "OptionLabel", "- 請選擇 -", "DropDownListMethodName", "CategoryList", "DropDownListName","最新消息")]
        public string News_Tag { get; set; }

        [Display(Name = "是否發布")]
        public bool News_IsPublish { get; set; }

        [Display(Name = "是否置頂")]
        public bool News_IsTop { get; set; }
        
        [ScaffoldColumn(true)]
        public DateTime News_CreateTime { get; set; }

        [ScaffoldColumn(false)]
        public string News_CreatorId { get; set; }

        [ScaffoldColumn(false)]
        public string News_CreatorUserName { get; set; }

        [ScaffoldColumn(false)]
        public DateTime News_UpdateTime { get; set; }

        [ScaffoldColumn(false)]
        public string News_UpdaterId { get; set; }

        [ScaffoldColumn(false)]
        public string News_UpdaterUserName { get; set; }

        [ScaffoldColumn(false)]
        public bool News_DelLock { get; set; }

        public NewsModel()
        {
            this.News_Id = Guid.NewGuid().ToString();
            this.News_Title = "";
            this.News_StartTime = DateTime.Now.ToString("yyyy-MM-dd");
            this.News_EndTime = DateTime.Now.ToString("yyyy-MM-dd");
            this.News_Content = "";
            this.News_CoverImage = "";
            this.News_IsPublish = true;
            this.News_IsTop = false;
            this.News_CreateTime = DateTime.Now;
            this.News_CreatorId = "";
            this.News_CreatorUserName = "系統管理員";
            this.News_UpdateTime = DateTime.Now;
            this.News_UpdaterId = "";
            this.News_UpdaterUserName = "系統管理員";
            this.News_DelLock = false;
        }

    }
}