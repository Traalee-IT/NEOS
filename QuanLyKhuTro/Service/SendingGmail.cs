using QuanLyKhuTro.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhuTro.Service
{
    public class SendingGmail
    {
        private static readonly string from = "nguyenvanphuc3603@gmail.com";
        private static readonly string pass = "mepz qhxp ovbq bjgz";

        //Gửi Gmail đến ngày thanh toán tiền trọ

        public static bool sendingEmail(string receiver, List<DichVu> list, float soDien, float soNuoc, float moneyElectric, float moneyWater, float totalMoney, string truongPhong, string tenPhong, float giaPhong)
        {
            try
            {
                string html = setUpTableHtml(list,soDien,soNuoc,moneyElectric,moneyWater,totalMoney,truongPhong,tenPhong,giaPhong);
                setUpEmail("Đến thời hạn thanh toán tiền trọ",receiver, html);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public static bool sendEmaiOverTime(string receiver, string tenPhong, float giaPhong)
        {
            try
            {
                string html = setUpSendEmailOverTimePayment(receiver, tenPhong, giaPhong);
                setUpEmail("Cảnh báo quá thời hạn thanh toán", receiver, html);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private static bool setUpEmail(string subject,string receiver,string content)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(from);
                mail.To.Add(receiver);   
                mail.Subject = subject;
                mail.Body = content;
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    try
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential(from, pass);
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        return false;
                    }

                }
            }
          
        }
        //Gửi tin nhắn quá hạn thanh toán
        private static string setUpSendEmailOverTimePayment(string receiver,string tenPhong,float giaPhong)
        {
            string messageBody = "<h3>Xin chào, " + receiver + " !</h3>" +
                "<p>Đã quá thời gian thanh toán tiền phòng</p>" +
                "<h2 style=\"color:rgb(112, 52, 225) \">" + tenPhong + "</h2>" +
                "<p style=\"font-size: 20\">Giá phòng: " + "<span style=\"color:red;font-weight:bold\">" + string.Format(new CultureInfo("vi-VN"), "{0:C}", giaPhong) + "</span></p>" +
                 "<h4>Vui lòng liên hệ với chủ trọ: \"Nguyễn Văn Phúc\" để biết thêm thông tin thanh toán.</h4>"+
                 "<p>Liên hệ: 0912376543 - nguyenvanphuc3603@gmail.com</p>";
            return messageBody;
        }

        //Cài đặt gửi email có dạng bảng
        private static string setUpTableHtml(List<DichVu> list,float soDien,float soNuoc,float moneyElectric,float moneyWater,float totalMoney,string truongPhong,string tenPhong,float giaPhong)
        {
            try
            {
                //string messageBody = "<font> </font><br><br>";

                string messageBody = "<h3>Xin chào " + truongPhong + " !</h3>" +
                "<p>Đã đến thời gian cần thanh toán tiền phòng của bạn</p>" +
                "<h2 style=\"color:rgb(112, 52, 225) \">" + tenPhong + "</h2>" +
                "<p style=\"font-size: 20\">Giá phòng: " + "<span style=\"color:red;font-weight:bold\">" + string.Format(new CultureInfo("vi-VN"), "{0:C}", giaPhong) + "</span></p>"+
                 "<h4>Số tiền bạn cần thanh toán là: " + "<span style=\"font-weight:bold; color:red\">" + string.Format(new CultureInfo("vi-VN"), "{0:C}", totalMoney) + "</span></h4>";

                if (list.Count ==0)
                    return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "Tên dịch vụ " + htmlTdEnd;
                messageBody += htmlTdStart + "Đơn vị tính " + htmlTdEnd;
                messageBody += htmlTdStart + "Giá tiền" + htmlTdEnd;
                messageBody += htmlTdStart + "Đã sử dụng" + htmlTdEnd;
                messageBody += htmlTdStart + "Thành tiền" + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;

                foreach(DichVu service in list)
                {
                    messageBody = messageBody + htmlTrStart;
                    messageBody = messageBody + htmlTdStart + service.TenDichVu + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + service.DonViTinh + htmlTdEnd;
                    messageBody = messageBody + htmlTdStart + string.Format(new CultureInfo("vi-VN"), "{0:C}", service.GiaTien) + htmlTdEnd;

                    if (service.TenDichVu.Equals("Điện"))
                    {
                        messageBody = messageBody + htmlTdStart + soDien + htmlTdEnd;
                        messageBody = messageBody + htmlTdStart + string.Format(new CultureInfo("vi-VN"), "{0:C}", moneyElectric) + htmlTdEnd;
                    }else if (service.TenDichVu.Equals("Nước"))
                    {
                        messageBody = messageBody + htmlTdStart + soNuoc + htmlTdEnd;
                        messageBody = messageBody + htmlTdStart + string.Format(new CultureInfo("vi-VN"), "{0:C}", moneyWater) + htmlTdEnd;
                    }
                    else
                    {
                        messageBody = messageBody + htmlTdStart + 1 + htmlTdEnd;
                        messageBody = messageBody + htmlTdStart + string.Format(new CultureInfo("vi-VN"), "{0:C}", service.GiaTien) + htmlTdEnd;
                    }
                    messageBody = messageBody + htmlTrEnd;     
                }
                messageBody += htmlTableEnd;
                return messageBody;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


    }
}
