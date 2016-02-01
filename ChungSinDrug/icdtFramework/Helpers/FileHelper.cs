using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace icdtFramework.Helpers
{
    public class FileHelper
    {
        public static void RemoveFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        public static void UploadFile(HttpPostedFileBase file, string targetDiretory)
        {
            if (!Directory.Exists(targetDiretory))
            {
                Directory.CreateDirectory(targetDiretory);
            }

            string fileName = String.Empty;
            fileName = file.FileName;
            string targetFilePath = Path.Combine(targetDiretory, fileName);
            file.SaveAs(targetFilePath);
        }

        public static void MoveFile(string oldPath, string newPath)
        {
            if (Directory.Exists(oldPath))
            {
                Directory.Move(oldPath, newPath);
            }
        }
    }
}