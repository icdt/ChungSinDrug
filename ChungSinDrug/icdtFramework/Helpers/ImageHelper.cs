using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace icdtFramework.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// 儲存圖片
        /// </summary>
        /// <param name="IOprefix"></param>
        /// <param name="image"></param>
        /// <param name="dateFN"></param>
        public static void SaveImage(string IOprefix, HttpPostedFileBase image, string dateFN = "")
        {
            if (!Directory.Exists(IOprefix))
            {
                Directory.CreateDirectory(IOprefix);
            }
            var finalFN = string.IsNullOrEmpty(dateFN) ? image.FileName : dateFN;

            var filepath = Path.Combine(IOprefix, finalFN);
            image.SaveAs(filepath);
        }

        /// <summary>
        /// 刪除圖片
        /// </summary>
        /// <param name="IOprefix"></param>
        /// <param name="url"></param>
        public static void DeleteImage(string IOprefix, string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            var filename = GetFileName(url);
            var filepath = Path.Combine(IOprefix, filename);
            if (!Directory.Exists(IOprefix) || !File.Exists(filepath))
            {
                return;
            }

            File.Delete(filepath);
        }

        /// <summary>
        /// 透過 HttpPostedFileBase 上完圖片 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static bool OptimizeNResize(HttpPostedFileBase file, string filePath, int Width, int Height)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            Bitmap original_image = new Bitmap(file.InputStream);

            Bitmap final_image = null;
            final_image = GraphicsHelper.Resize(original_image, 500, GraphicsHelper.ResizeMode.ByWidth);

            try
            {
                final_image.Save(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                if (original_image != null) original_image.Dispose();
                if (final_image != null) final_image.Dispose();
            }
        }

        /// <summary>
        /// 透過 Bitmap 上完圖片 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="filePath"></param>
        /// <param name="Width"></param>
        /// <param name="Height"></param>
        /// <returns></returns>
        public static bool OptimizeNResize(Bitmap bitmap, string filePath, int Width, int Height)
        {
            Bitmap original_image = bitmap;

            Bitmap final_image = null;
            Graphics graphic = null;
            int reqW = Width;
            int reqH = Height;
            final_image = new Bitmap(reqW, reqH);
            graphic = Graphics.FromImage(final_image);
            graphic.FillRectangle(new SolidBrush(Color.Transparent),
                new Rectangle(0, 0, reqW, reqH));
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic; /* new way */
            graphic.DrawImage(original_image, 0, 0, reqW, reqH);

            if (original_image != null) original_image.Dispose();
            try
            {
                final_image.Save(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally
            {
                if (graphic != null) graphic.Dispose();
                if (final_image != null) final_image.Dispose();
            }
        }

        /// <summary>
        /// url轉成小寫
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsOutside(string url)
        {
            var lowerurl = url.ToLower();
            return lowerurl.Contains("http://") || lowerurl.Contains("https://");
        }

        /// <summary>
        /// 取得url的檔案名稱
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetFileName(string url)
        {
            if (IsOutside(url))
            {
                return "";
            }
            Regex regex = new Regex(@"[^\/]+$");
            var result = regex.Match(url);
            if (result.Success)
            {
                return result.Value;
            }
            return "";
        }

        /// <summary>
        /// 轉成日期格式檔名的圖片
        /// </summary>
        /// <param name="fn"></param>
        /// <returns></returns>
        public static string GetDateFileName(string fn)
        {
            var extension = System.IO.Path.GetExtension(fn);
            var fileshortname = System.IO.Path.GetFileNameWithoutExtension(fn);
            var newfilename = fileshortname + DateTime.Now.ToString("MMddhhmmssfff") + extension;
            return newfilename;
        }

        /// <summary>
        /// Bytes轉成Bitmap
        /// </summary>
        /// <param name="Bytes"></param>
        /// <returns></returns>
        public static Bitmap BytesToBitmap(byte[] Bytes)
        {
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(Bytes);
                return new Bitmap((Image)new Bitmap(stream));
            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }
            finally
            {
                stream.Close();
            }
        }

        /// <summary>
        /// 處理圖片壓縮的部分
        /// </summary>
        public class GraphicsHelper
        {
            public static Bitmap Combine(List<Bitmap> SourceImages)
            {
                //找出最大Size的Image
                int Width = SourceImages.Max(s => s.Width);
                int Height = SourceImages.Max(s => s.Height);

                Bitmap Result = new Bitmap(Width, Height);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(Result);

                foreach (Bitmap Source in SourceImages)
                {
                    gr.DrawImage(Source, 0, 0);
                }

                return Result;
            }

            public enum ResizeMode { ByWidth, ByHeight }
            public static Bitmap Resize(Bitmap OriginalImage, int MaxLength, ResizeMode Mode)
            {
                int OriginalWidth = OriginalImage.Width;
                int OriginalHeight = OriginalImage.Height;

                //計算圖片要縮小的比例
                double ResizePercentage = 0;

                switch (Mode)
                {
                    case ResizeMode.ByWidth:
                        ResizePercentage = (double)OriginalWidth / (double)MaxLength;
                        break;
                    case ResizeMode.ByHeight:
                        ResizePercentage = (double)OriginalHeight / (double)MaxLength;
                        break;
                }

                //填入要縮小的寬度與高度
                int NewWidth = (int)(Math.Ceiling(OriginalWidth / ResizePercentage));
                int NewHeight = (int)(Math.Ceiling(OriginalHeight / ResizePercentage));

                //高品質縮圖
                Bitmap ResizedBitmap = new Bitmap(NewWidth, NewHeight);
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(ResizedBitmap);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.Default;
                gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
                gr.DrawImage(OriginalImage, 0, 0, NewWidth, NewHeight);

                return ResizedBitmap;
            }

            public enum ScopeMode { InScope, OutScope }
            public static Bitmap ResizeByScope(Bitmap OriginalImage, int ScopeWidth, int ScopeHeight, ScopeMode ScopeMode = ScopeMode.InScope)
            {
                Bitmap ScopeBitmap = new Bitmap(ScopeWidth, ScopeHeight);

                double WidthPercentage = (double)OriginalImage.Width / (double)ScopeWidth;
                double HeightPercentage = (double)OriginalImage.Height / (double)ScopeHeight;

                //確定縮放模式
                Bitmap ResizedBitmap = null;
                switch (ScopeMode)
                {
                    case ScopeMode.InScope:
                        if (WidthPercentage > HeightPercentage)
                        { ResizedBitmap = Resize(OriginalImage, ScopeWidth, ResizeMode.ByWidth); }
                        else
                        { ResizedBitmap = Resize(OriginalImage, ScopeHeight, ResizeMode.ByHeight); }
                        break;

                    case ScopeMode.OutScope:
                        if (WidthPercentage > HeightPercentage)
                        { ResizedBitmap = Resize(OriginalImage, ScopeHeight, ResizeMode.ByHeight); }
                        else
                        { ResizedBitmap = Resize(OriginalImage, ScopeWidth, ResizeMode.ByWidth); }
                        break;
                }

                //置中座標補償
                int LeftX = (ScopeBitmap.Width - ResizedBitmap.Width) / 2;
                int TopY = (ScopeBitmap.Height - ResizedBitmap.Height) / 2;

                //Graphics
                System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(ScopeBitmap);
                gr.Clear(Color.Black);
                gr.DrawImage(ResizedBitmap, LeftX, TopY, ResizedBitmap.Width, ResizedBitmap.Height);

                return ScopeBitmap;
            }
        }


    }
}