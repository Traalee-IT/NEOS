using QuanLyKhuTro.DAO;
using QuanLyKhuTro.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Globalization;
using QuanLyKhuTro.Service;
using QuanLyKhuTro.CustomDesign;

namespace QuanLyKhuTro.View
{
    public partial class FormThanhToan : Form
    {
        private List<DichVu> listService;
        private Room room;
        private float totalMoneyElectric = 0;
        private float totalMoneyWater = 0;
        private float totalMoney;
        DateTime currentTime = DateTime.Now;
        public FormThanhToan()
        {
            InitializeComponent();

        }

        public FormThanhToan(Room obj)
        {
            this.room = obj;
            InitializeComponent();
            loadForm();
        }

        private void loadForm()
        {
            lbCurrentTime.Text = currentTime.ToString("dd-MM-yyyy");
            txtMaPhong.Text = room.ID_Room.ToString();
            foreach (MemberRoom item in room.memberList)
            {
                if (item.chucVu.Equals("Trưởng phòng"))
                {
                    txtTruongPhong.Text = item.customer.FullName;
                    break;
                }
            }

            listService = DichVuDao.getInstance().getServiceUsed(room.ID_Room);
            dtGridViewService.DataSource = listService;


            foreach (DichVu service in listService)
            {
                if (service.TenDichVu.Equals("Điện") || service.TenDichVu.Equals("Nước"))
                    continue;
                totalMoney += service.GiaTien;
            }
            totalMoney += room.price;
            lbTotalMoney.Text = string.Format(new CultureInfo("vi-VN"), "{0:C}", totalMoney);

        }

        //Khởi tạo form loading


        /// <summary>
        /// Sau khi nhấn gửi email thì dữ liệu sẽ được lưu vào trong hóa đơn ở trạng thái chờ thanh toán
        /// sau lấy dữ liệu lên sẽ không cần phải nhập lại dữ liệu
        /// </summary>
        private void thanhToan(string status)
        {
            LichSuThanhToan ls = new LichSuThanhToan();
            ls.IDRoom = room.ID_Room;
            ls.NguoiThanhToan = txtNguoiThanhToan.Text;
            ls.soDien = (float)nbSoDien.Value;
            ls.soNuoc = (float)nbSoNuoc.Value;
            ls.status = status;
            ls.totalMoney = totalMoney;

            bool result = PaymentHistoryDAO.getInstance().InsertPayment(ls, listService);

            FinnishWorkerLoading(result); // Truyền kết quả để hiển thị MessageBox

            if(result) SetButtonState(btnSendEmail, false);
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            StartBackgroundWork(1);
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            loadingAnimation.Visible = true;
            StartBackgroundWork(2);
        }

        private void nbSoDien_ValueChanged(object sender, EventArgs e)
        {
            tinhToanTien();
        }

        private void nbSoNuoc_ValueChanged(object sender, EventArgs e)
        {
            tinhToanTien();
        }

        /// <summary>
        /// Tính toán tiền điện + nước + dịch vụ
        /// Do người dùng có thể sẽ không chỉ nhấn up down mà nhập vào nên dẫn đến khó khăn là phải tính toán lại
        /// từ đầu các dịch vụ và tính toán lại số tiền điện nước để hiển thị lên UI
        /// </summary>
        private void tinhToanTien()
        {
            totalMoneyElectric = 0;
            totalMoneyWater = 0;
            totalMoney = 0;
            foreach (DichVu dv in listService)
            {
                if (dv.TenDichVu.Equals("Điện"))
                {
                    totalMoneyElectric = (int)nbSoDien.Value * dv.GiaTien;
                }
                else if (dv.TenDichVu.Equals("Nước"))
                {
                    totalMoneyWater = (int)nbSoNuoc.Value * dv.GiaTien;
                }
                else
                {
                    totalMoney += dv.GiaTien;
                }
            }

            totalMoney += totalMoneyElectric + totalMoneyWater;
            totalMoney += room.price;
            lbTotalMoney.Text = string.Format(new CultureInfo("vi-VN"), "{0:C}", totalMoney);
        }


        private void StartBackgroundWork(int functionCode)
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync(functionCode);
            }
            else
            {
                MessageBox.Show("BackgroundWorker is busy. Please wait for the current task to complete.");
            }
        }


        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int functionCode = (int)e.Argument;

            switch (functionCode)
            {
                case 1: //Gửi eamil
                    sendEmailForCustomer();
                    break;
                case 2: //Thanh toán
                    thanhToan("Đã thanh toán");
                    SetButtonState(btnThanhToan, false);
                    break;
                   
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           /* loadingAnimation.Visible = false;

            if (e.Result.ToString() == "Success")
            {
                CustomMessageBox.Show("Tác vụ đã hoàn thành!");
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
            }*/
        }
       
        private void SetButtonState(Button button,bool isEnabled)
        {
            if (button.InvokeRequired)
            {
                // Nếu không ở trong luồng chính, thực hiện Invoke để chuyển tác vụ đến luồng chính
                button.Invoke(new MethodInvoker(() => SetButtonState(button,isEnabled)));
            }
            else
            {
                // Thực hiện thay đổi trạng thái của nút
                button.Enabled = isEnabled;
            }
        }

        private void FinnishWorkerLoading(bool result)
        {
            if (loadingAnimation.InvokeRequired)
            {
                // Nếu không ở trong luồng chính, thực hiện Invoke để chuyển tác vụ đến luồng chính
                loadingAnimation.Invoke(new MethodInvoker(() => FinnishWorkerLoading(result)));
            }
            else
            {
                // Thực hiện thay đổi trạng thái của nút
                loadingAnimation.Visible = false;

                if (result)
                {
                    CustomMessageBox.Show("Tác vụ đã hoàn thành!");
                }
                else
                {
                    CustomMessageBox.Show("Có lỗi xảy ra, thử lại sau!",
                                    "Error-Stop Icon",
                                    MessageBoxButtons.RetryCancel,
                                    MessageBoxIcon.Error);
                }
            }
        }

        private void sendEmailForCustomer()
        {
            string gmail = null;
            foreach (MemberRoom item in room.memberList)
            {
                if (item.chucVu.Equals("Trưởng phòng"))
                {
                    gmail = item.customer.Email;
                    break;
                }
            }

            if (gmail == null || gmail.Length == 0)
            {
                FinnishWorkerLoading(false);
                return;
            }

            if (SendingGmail.sendingEmail(gmail, listService, (float)nbSoDien.Value, (float)nbSoNuoc.Value, totalMoneyElectric, totalMoneyWater, totalMoney, txtTruongPhong.Text, room.name_Room, room.price))
            {
                thanhToan("Chờ thanh toán");

            }
            else
            {
                FinnishWorkerLoading(false);
            }
        }

    }
}
