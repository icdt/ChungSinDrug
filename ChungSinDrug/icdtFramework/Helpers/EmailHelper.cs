using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ChungSinDrug.icdtFramework.Helpers
{
    public static class EmailHelper
    {
        private const string 信箱帳號 = "";
        private const string 信箱密碼 = "";

        public static void SendMail(List<string> ReceivingMails, string SentName, string MailSubject, string MailBody)
        {
            try
            {
                MailMessage Mail = new MailMessage();  //信件本體宣告

                Mail.From = new MailAddress(信箱帳號, SentName);

                foreach (string ReceivingMail in ReceivingMails)
                { Mail.Bcc.Add(ReceivingMail); }//收件人

                Mail.Priority = MailPriority.High;  //優先等級
                Mail.Subject = MailSubject; //主旨

                //處理Mail的內容
                Mail.Body = MailBody;  //Email 內容
                Mail.IsBodyHtml = true;  // 設定Email 內容為HTML格式
                Mail.BodyEncoding = System.Text.Encoding.UTF8;

                // 設定SMTP伺服器
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Credentials = new System.Net.NetworkCredential(信箱帳號, 信箱密碼);
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(Mail);


                Mail.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

    }
}

//public class MailManager
//{
//    public static void RegisterUser(string Account, string Email, string Name, string AuthUrl)
//    {
//        string Content = string.Format(" {0}  你好<br /> "
//                                      + " 恭喜你註冊成功<br /> "
//                                      + " 請點選以下網址，完成認證<br /> "
//                                      + " <a href='{1}'>{2}</a>", Name, AuthUrl, AuthUrl);

//        SendMail(new List<string>() { Email }, "系統管理", "註冊會員通知", Content);
//    }

//    public static void ForgetPassword(string Email, string Name, string AuthUrl)
//    {
//        string Content = string.Format(" {0}  你好<br /> "
//                                   + " 請點選以下網址，完成密碼修改<br /> "
//                                   + " <a href='{1}'>{2}</a>", Name, AuthUrl, AuthUrl);


//        SendMail(new List<string>() { Email }, "系統管理", "密碼信發送", Content);
//    }

//    public static void SendEPapper(string Email, string Title, string FileName, string Link)
//    {
//        string Content = "<a href='" + Link + "'><img src='" + "http://" + HttpContext.Current.Request.Url.Host + "/" + FileName + "' width='750'></a>";


//        SendMail(new List<string>() { Email }, "系統管理", Title, Content);
//    }

//    //ReceivingMail：收件人  SentName：寄件人名字  MailSubject：信件主旨  MailBody：信件內容 
//    public static void SendMail(string ReceivingMail, string SentName, string MailSubject, string MailBody)
//    {
//        List<string> lstMails = new List<string>();
//        lstMails.Add(ReceivingMail);
//        SendMail(lstMails, SentName, MailSubject, MailBody);
//    }
//    public static void SendMail(List<string> ReceivingMails, string SentName, string MailSubject, string MailBody)
//    {
//        try
//        {
//            MailMessage Mail = new MailMessage();  //信件本體宣告

//            Mail.From = new MailAddress(ConfigManager.Get(ConfigKey.信箱帳號), SentName);

//            foreach (string ReceivingMail in ReceivingMails)
//            { Mail.Bcc.Add(ReceivingMail); }//收件人

//            Mail.Priority = MailPriority.High;  //優先等級
//            Mail.Subject = MailSubject; //主旨

//            //處理Mail的內容
//            Mail.Body = MailBody;  //Email 內容
//            Mail.IsBodyHtml = true;  // 設定Email 內容為HTML格式
//            Mail.BodyEncoding = System.Text.Encoding.UTF8;

//            // 設定SMTP伺服器
//            SmtpClient SmtpServer = new SmtpClient();
//            SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigManager.Get(ConfigKey.信箱帳號), ConfigManager.Get(ConfigKey.信箱密碼));
//            SmtpServer.Port = 587;
//            SmtpServer.Host = "smtp.gmail.com";
//            SmtpServer.EnableSsl = true;

//            SmtpServer.Send(Mail);


//            Mail.Dispose();
//        }
//        catch (Exception ex)
//        {

//        }
//    }
//}