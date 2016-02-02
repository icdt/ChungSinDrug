﻿using icdtFramework.CustomViewTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChungSinDrug.Models
{
    public class News
    {
        [Key]
        public string News_Id { get; set; }

        [Display(Name = "標題")]
        public string News_Title { get; set; }

        [Display(Name = "開始時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [UIHint("DatePicker")]
        public DateTime News_StartTime { get; set; }

        [Display(Name = "結束時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [UIHint("DatePicker")]
        public DateTime News_EndTime { get; set; }

        [NotListShow]
        [Display(Name = "內文")]
        public string News_Content { get; set; }

        [Display(Name = "封面圖片")]
        public string News_CoverImage { get; set; }

        [Required(ErrorMessage = "Category 為必填")]
        [UIHint("DropDownListTemplate", "", "OptionLabel", "- 請選擇 -", "DropDownListMethodName", "CategoryList")]
        public string News_Tag { get; set; }

        [Display(Name = "是否發布")]
        public bool News_IsPublish { get; set; }

        [Display(Name = "是否置頂")]
        public bool News_IsTop { get; set; }

        [NotListShow]
        [NotEditable]
        public DateTime News_CreateTime { get; set; }

        [NotListShow]
        [NotFormShow]
        public string News_CreatorId { get; set; }

        [NotListShow]
        [NotEditable]
        public string News_CreatorUserName { get; set; }

        [NotListShow]
        [NotEditable]
        public DateTime News_UpdateTime { get; set; }

        [NotListShow]
        [NotFormShow]
        public string News_UpdaterId { get; set; }

        [NotListShow]
        [NotEditable]
        public string News_UpdaterUserName { get; set; }

        [NotListShow]
        [NotFormShow]
        public bool News_DelLock { get; set; }

        public News()
        {
            this.News_Id = Guid.NewGuid().ToString();
            this.News_Title = "";
            this.News_StartTime = DateTime.Now;
            this.News_EndTime = DateTime.Now;
            this.News_Content = "";
            this.News_CoverImage = "";
            this.News_IsPublish = true;
            this.News_IsTop = false;
            this.News_CreateTime = DateTime.Now;
            this.News_CreatorId = "";
            this.News_CreatorUserName = "";
            this.News_UpdateTime = DateTime.Now;
            this.News_UpdaterId = "";
            this.News_UpdaterUserName = "";
            this.News_DelLock = false;
        }

    }
}