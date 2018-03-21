using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ShopLapTop.LopMoRong
{
    public class GuiMail
    {
        public GuiMail()
        {

        }
        SmtpClient smtpClient = new SmtpClient();

        //xác định smtpserver để gửi mail, với gmail là smtp.gmail.com
        string smtpServer = "smtp.gmail.com";
        public string SmtpServer
        {
            get { return smtpServer; }
            set { smtpServer = value; }
        }

        //Gửi từ mail nào, là một địa chỉ mail từ GMAIL 
        //string smtpMailFrom = "__________________@gmail.com";
        string smtpMailFrom = "c15udpm1@gmail.com";
        public string SmtpMailFrom
        {
            get { return smtpMailFrom; }
            set { smtpMailFrom = value; }
        }

        //user đăng nhập vào gmail
        string smtpUser = "c15udpm1@gmail.com";
        public string SmtpUser
        {
            set { smtpUser = value; }
        }

        //mật khẩu đăng nhập gmail
        string smtpPassword = "a0123456789";
        public string SmtpPassword
        {
            set { smtpPassword = value; }
        }

        //port của smtpserver khi dùng gmail là 587 hoặc 465
        int smtpPort = 587;
        public int SmtpPort
        {
            get { return smtpPort; }
            set { smtpPort = value; }
        }
        public string SendMail(string strMailTo, string strMailSubject, string strContent, bool isHTMLFormat)
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.From = new MailAddress(smtpMailFrom);
                //mail.ReplyTo = new MailAddress(smtpMailFrom);

                //gửi file đính kèm
                //Attachment fileAttach=new Attachment("duong dan");
                //mail.Attachments.Add(fileAttach);

                mail.To.Add(strMailTo);
                mail.Subject = strMailSubject;
                if (isHTMLFormat)
                {
                    mail.IsBodyHtml = true;
                    mail.Body = string.Format(@"<html><head><title><u>{0}</u></title></head><body>{1}<br><br><center>
<b>Gửi từ website bán hàng của Tân đẹp trai - Đập Chai</b><br></center></body>", strMailSubject, strContent);
                }
                else
                {
                    mail.IsBodyHtml = false;
                    mail.Body = strContent;
                }
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                smtpClient = new SmtpClient();
                smtpClient.Host = smtpServer;
                smtpClient.Port = smtpPort;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(smtpUser, smtpPassword);//cơ chế chứng thực xác nhận email
                smtpClient.EnableSsl = true;//xác định cơ chế bảo mật mã hóa kết nối
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "Successful!";
        }
    }
}