using QuanLyKhuTro.CustomDesign;
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

namespace QuanLyKhuTro.View
{
    public partial class Home : Form
    {
        private  static int widthHome;
        private  static int heightHome;
        private static int widthPanelChild;
        private static int heighthPanelChild;
        private Color primaryColor = Color.SaddleBrown;

        public static Account account;

        public Home()
        {
            InitializeComponent();
            hiddenSubMenu();
           
        }

        public Home(Account a)
        {
            InitializeComponent();
            account = a;
            hiddenSubMenu();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void Home_Load(object sender, EventArgs e)
        {
            widthHome = this.Width;
            heightHome = this.Height;
            widthPanelChild = panelChildForm.Width;
            heighthPanelChild = panelChildForm.Height;
            lbFullName.Text = "Hi, " + account.Name;
            lbDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
            // Bắt đầu Timer
            timer.Start();
        }


        private void hiddenSubMenu()
        {
            panelBaoCaoThongKeMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hiddenSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private Form activeForm = null;

        private void openChildForm(Form childForm)
        {

            this.Size = new Size(widthHome, heightHome);
            // Bắt sự kiện Load của form con
            childForm.Load += (sender, e) =>
            {
                // Lấy kích thước của form con
                int formWidthChild = childForm.Width;
                int formHeightChild = childForm.Height;


                // Tính toán kích thước mới của form cha
               if(formWidthChild > widthPanelChild)
                {
                   
                    this.Width += (formWidthChild - widthPanelChild);
                }
                else 
                {
                   
                    this.Width -= (widthPanelChild - formWidthChild);
                }

               if(formHeightChild > heighthPanelChild)
                {
                    
                    this.Height += (formHeightChild - heighthPanelChild);
                }
                else
                {
                 
                    this.Height -= (heighthPanelChild - formHeightChild);
                }
  
                // Đặt lại kích thước của form cha
                panelChildForm.Size = new Size(formWidthChild, formHeightChild);
                
          
            };

            setUpClickMenu(childForm.Text);
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
            

            

        }


        private void resetBackground()
        {
            btnRoom.BackColor = primaryColor;
            btnManagamentCustomer.BackColor = primaryColor;
            btnService.BackColor = primaryColor;
            btnCartInOut.BackColor = primaryColor;
            btnQLChiTieu.BackColor = primaryColor;
            btnBaoCaoThongKe.BackColor = primaryColor;
            btnContract.BackColor = primaryColor;
           
        }
        private void setUpClickMenu(string name)
        {
            resetBackground();
            switch (name)
            {
                case "Quản lý phòng":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.HouseChimneyUser;
                    lbtitelForm.Text = "Quản lý phòng";
                    btnRoom.BackColor = Color.DarkSeaGreen;
                    break;
                case "Quản lý khách hàng":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
                    lbtitelForm.Text = "Quản lý khách hàng";
                    btnManagamentCustomer.BackColor = Color.DarkSeaGreen;
                    break;
                case "Quản lý dịch vụ":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.Scroll;
                    lbtitelForm.Text = "Quản lý dịch vụ";
                    btnService.BackColor = Color.DarkSeaGreen;
                    break;
                case "Quản lý thẻ ra vào":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.CreditCardAlt;
                    lbtitelForm.Text = "Quản lý thẻ ra vào";
                    btnCartInOut.BackColor = Color.DarkSeaGreen;
                    break;
                case "Quản lý chi tiêu":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.MoneyBillTransfer;
                    lbtitelForm.Text = "Quản lý chi tiêu";
                    btnQLChiTieu.BackColor = Color.DarkSeaGreen;
                    break;
                case "Quản lý hợp đồng":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.PenToSquare;
                    lbtitelForm.Text = "Quản lý hợp đồng";
                    btnContract.BackColor = Color.DarkSeaGreen;
                    break;
                case "Thống kê doanh thu":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.Coins;
                    lbtitelForm.Text = "Thống kê doanh thu";
                    btnBaoCaoThongKe.BackColor = Color.DarkSeaGreen;
                    break;

                case "Phòng nợ thanh toán":
                    iconForm.IconChar = FontAwesome.Sharp.IconChar.Warning;
                    lbtitelForm.Text = "Phòng nợ thanh toán";
                    btnBaoCaoThongKe.BackColor = Color.DarkSeaGreen;
                    break;
            }
        }





        #region Events
        private void logoPic_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            this.Size = new Size(widthHome, heightHome);
            iconForm.IconChar = FontAwesome.Sharp.IconChar.Dashboard;
            lbtitelForm.Text = "Trang chủ";
            resetBackground();
        }

        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            hiddenSubMenu();
            openChildForm(new ThongKeDoanhThu());
        }

        private void btnPhongNoThanhToan_Click(object sender, EventArgs e)
        {
            hiddenSubMenu();
            openChildForm(new PhongNoThanhToan());
        }

        private void btnRoom_Click_1(object sender, EventArgs e)
        {      
            openChildForm(new RoomManagerForm());
        }

        private void btnManagamentCustomer_Click_1(object sender, EventArgs e)
        {
            openChildForm(new QuanLyKhachHang());
        }

        private void btnService_Click_1(object sender, EventArgs e)
        {
            openChildForm(new QuanLyDichVu());
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyHopDong());
        }

        private void btnQLChiTieu_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyChiTieu());
        }

        private void btnCartInOut_Click(object sender, EventArgs e)
        {
            openChildForm(new QuanLyTheRaVao());
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBaoCaoThongKeMenu);
        }
        #endregion


        #region SetUpDesign

        public const int WM_NCLBUTTONDOWN = 0x112;
        public const int HT_CAPTION = 0xf012;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();


        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.LightCoral;
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Maroon;
        }

        private void btnMinisize_MouseHover(object sender, EventArgs e)
        {
            btnMinisize.BackColor = Color.DarkOrange;
        }

        private void btnMinisize_MouseLeave(object sender, EventArgs e)
        {
            btnMinisize.BackColor = Color.Maroon;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            // Hiển thị giờ, phút và giây trong Label
            labelTime.Text = now.ToString("HH:mm:ss");
        }

        private void btnMinisize_Click(object sender, EventArgs e)
        {
            // Thu nhỏ form
            this.WindowState = FormWindowState.Minimized;
        }







        #endregion

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var result = CustomMessageBox.Show("Bạn muốn đăng xuất?",
                "Đăng xuất",
                MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                new Login().Show();
                this.Close();
            }
            
        }

        private void lbFullName_Click(object sender, EventArgs e)
        {
            new QuanLyTaiKhoan(account).ShowDialog();
        }

        
    }
}
