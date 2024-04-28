using QuanLyKhuTro.CustomDesign;
using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhuTro.View
{
    public partial class PhongNoThanhToan : Form
    {
        DateTime currentTime = DateTime.Now;
        public PhongNoThanhToan()
        {
            InitializeComponent();
            lbTimeNow.Text = currentTime.ToString("dd-MM-yyyy");
            getData(currentTime.Month, currentTime.Year);
        }

        private void getData(int month, int year)
        {

            dataGridView.DataSource = PaymentHistoryDAO.getInstance().PhongNoThanhToan(month, year).Tables[0];
            dataGridView.Columns[5].Visible = false;
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            int month = dateTimePicker.Value.Month;
            int year = dateTimePicker.Value.Year;
            getData(month, year);
        }

        private void sendEmail_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void sendEmail()
        {
            int failed = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                object email = row.Cells[5].Value;
                object tenPhong = row.Cells[1].Value;
                object giaPhong = row.Cells[2].Value;
                if (email != DBNull.Value || tenPhong != DBNull.Value || giaPhong != DBNull.Value)
                {
                    string cleanedString = giaPhong.ToString().Replace(",", ""); // Loại bỏ dấu ","
                    float floatValue;
                    if (float.TryParse(cleanedString, out floatValue))
                    {
                        try
                        {
                            if (!SendingGmail.sendEmaiOverTime(email.ToString(), tenPhong.ToString(), floatValue))
                            {
                                failed++;
                            }
                            Thread.Sleep(500);

                        }
                        catch
                        {
                            Console.WriteLine("Có lỗi khi gửi email.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Không thể chuyển đổi chuỗi thành kiểu float.");
                        break;
                    }

                }

            }
            if (failed == 0)
            {
                FinnishWorkerLoading(true, "Đã gửi thành công");
          
            }
            else
            {
                FinnishWorkerLoading(false, "Có lỗi xảy ra, " + failed + " phòng chưa được gửi!");      
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            sendEmail();
        }

      
        private void FinnishWorkerLoading(bool result,string messs)
        {
            if (loadingAnimation.InvokeRequired)
            {
                // Nếu không ở trong luồng chính, thực hiện Invoke để chuyển tác vụ đến luồng chính
                loadingAnimation.Invoke(new MethodInvoker(() => FinnishWorkerLoading(result, messs)));
            }
            else
            {
                // Thực hiện thay đổi trạng thái của nút
                loadingAnimation.Visible = false;               
                if (result)
                {
                    CustomMessageBox.Show(messs);
                    btnSendEmail.Enabled = false;
                }
                else
                {
                    CustomMessageBox.Show(messs,
                                    "Error-Stop Icon",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
